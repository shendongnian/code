        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string url = textBox1.Text;
            LoadSiteContent(url);
        }
        public string LoadSiteContent(string url)
        {
            //create a new WebClient object
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new    DownloadStringCompletedEventHandler(DownloadStringCallback2);
           client.DownloadStringAsync(new Uri(url));
        }
        private static void DownloadStringCallback2(Object sender, DownloadStringCompletedEventArgs e)
        {
           // If the request was not canceled and did not throw
           // an exception, display the resource.
           if (!e.Cancelled && e.Error == null)
           {
               textBlock1.Text = (string)e.Result;
               //If you get the cross-thread exception then use the following line instead of the above
               //Dispatcher.BeginInvoke(new Action (() => textBlock1.Text = (string)e.Result));
           } 
        }
