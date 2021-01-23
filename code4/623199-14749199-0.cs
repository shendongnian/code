       public void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                pbDownload.Value = e.ProgressPercentage;
                Application.DoEvents();
            }
