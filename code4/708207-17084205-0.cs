    private void button1_Click(object sender, EventArgs e)
      {
       string url = "http://framework.zend.com/releases/ZendFramework-1.11.11/ZendFramework-1.11.11.zip";
       WebClient downloader = new WebClient();
       downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(downloader_DownloadFileCompleted);
       downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloader_DownloadProgressChanged);
       downloader.DownloadFileAsync(new Uri(url), "C:\\temp.zip");
      }
    
     void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
       {
          label1.Text = e.BytesReceived + " " + e.ProgressPercentage;
        }
      void downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
       {
           if (e.Error != null)
             MessageBox.Show(e.Error.Message);
           else
             MessageBox.Show("Completed!!!");
       }
