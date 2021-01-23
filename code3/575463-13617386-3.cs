    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Text.RegularExpressions;
     
    namespace WpfApplication3
     
    {
        public partial class BrowserWindow : Window
        {
            static string scope = "wl.signin wl.calendars wl.offline_access wl.contacts_calendars";
            static string client_id = "your-client-id";
            static Uri signInUrl = new Uri(String.Format(@"https://login.live.com/oauth20" + 
              @"_authorize.srf?client_id={0}&redirect_uri=https://login.live.com/" + 
              @"oauth20_desktop.srf&response_type=code&scope={1}", client_id, scope));
            MainWindow mainWindow = new MainWindow();
     
            public BrowserWindow()
            {
                InitializeComponent();
                webBrowser.Navigate(signInUrl);
            }
     
            private void webBrowser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
            {
                if (e.Uri.AbsoluteUri.Contains("code="))
                {
                    if (App.Current.Properties.Contains("auth_code"))
                    {
                        App.Current.Properties.Clear();
                    }
                    string auth_code = Regex.Split(e.Uri.AbsoluteUri, "code=")[1];
                    App.Current.Properties.Add("auth_code", auth_code);
                    this.Close();
                }
            }
        }
    } 
