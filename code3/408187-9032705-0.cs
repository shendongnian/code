     private void button1_Click(object sender, RoutedEventArgs e)
        {
            string address =
                "https://foursquare.com/oauth2/authenticate" +
                "?client_id=" + CLIENT_ID +
                "&response_type=token" +
                "&redirect_uri=" + CALLBACK_URI;
            webBrowser1.Navigated += new EventHandler<System.Windows.Navigation.NavigationEventArgs>(webBrowser1_Navigated);
            webBrowser1.Navigate(new Uri(address, UriKind.Absolute));
        }
        void webBrowser1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            response = e.Uri.ToString();
            System.Diagnostics.Debug.WriteLine(e.Uri.ToString());
            if (response.LastIndexOf("access_token=") != -1)
            {
                string token = response.Substring(response.LastIndexOf("#access_token=") + "#access_token=".Length);
                System.Diagnostics.Debug.WriteLine("TOKEN: " + token);
            }
        }
