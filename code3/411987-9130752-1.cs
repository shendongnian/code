        private void StartDownload_Click(object sender, RoutedEventArgs e)
        {
            if (this.FileURL.Text.Trim() != "")
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                    //todo: handle mime-type and location to save to!
                    wc.DownloadFileAsync(new Uri(this.FileURL.Text), "SomeFileName.ext");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Set the progress bar back to nothing
            if (MessageBox.Show("Download Completed!", "Finished!", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                this.DownloadProgress.Value = 0;
            }
        }
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //update the progress bar based on the percentage completed.
            this.DownloadProgress.Value = (double)e.ProgressPercentage;
        }
