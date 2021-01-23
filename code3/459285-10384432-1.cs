       private void goto_google(object sender, RoutedEventArgs e)
       {
           ShowInBrowser("http://www.google.com");
       }
       private void ShowInBrowser(string url)
       {
           Microsoft.Phone.Tasks.WebBrowserTask wbt = new Microsoft.Phone.Tasks.WebBrowserTask();
           wbt.Uri = new Uri(url);
           wbt.Show();
       }
