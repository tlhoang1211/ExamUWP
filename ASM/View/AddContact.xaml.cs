using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContact : Page
    {
        public AddContact()
        {
            this.InitializeComponent();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            using (var conn = new SQLiteConnection("ContactDatabase.db"))
            {
                using (var stt = conn.Prepare("INSERT INTO Contacts (name, PhoneNumber ) VALUES (?, ?) "))
                {
                    stt.Bind(1, name.Text);
                    stt.Bind(2, phone.Text);
                    var result = stt.Step();
                    if (result == SQLiteResult.DONE)
                    {
                        Debug.WriteLine("Success");
                    }
                    else
                    {
                        Debug.WriteLine("Fail");
                    }
                }

            }
        }
    }
}
