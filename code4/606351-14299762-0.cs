        private void bargo_Click(object sender, RoutedEventArgs e)
        {
            string url = bar.Text;
            if (!url.StartsWith("http://"))
            {
                url = "http://" + url;
            }
            web.Navigate(new Uri(url);
        }
