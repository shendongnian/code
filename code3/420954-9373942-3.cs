     private void tbWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += HttpsCompleted;
            wc.DownloadStringAsync(new Uri("http://en.wikipedia.org/w/api.php?action=opensearch&search=" + tbWord.Text)); 
        }
        private void HttpsCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                 
                 //do what ever 
                 //with using e.Result
            }
        } 
