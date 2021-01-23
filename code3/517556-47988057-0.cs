            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://www.colorado.gov/pacific/sites/default/files/Income1.pdf"), @"output/" + DateTime.Now.Ticks ("")+ ".pdf", FileMode.Create);
          }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar = e.ProgressPercentage;
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }
    }
}
