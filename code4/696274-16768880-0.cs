    private void Download(string url, string downloadDirectory)
    {
        WebClient wc = new WebClient();
        wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
        wc.DownloadFileCompleted += new AsyncCompletedEventHandler((sender, e) => DownloadComplete(sender, e, wc));
        wc.DownloadFileAsync(new Uri(url), downloadDirectory + "temp");
    }
    private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
    {
        downloadProgressBar.Value = e.ProgressPercentage;
    }
    private void DownloadComplete(object sender, AsyncCompletedEventArgs e, WebClient wc)
    {
        string filename = new ContentDisposition(wc.ResponseHeaders["Content-Disposition"].ToString()).FileName;
        if (File.Exists(downloadDirectory + "temp"))
        {
            if (File.Exists(downloadDirectory + filename))
                File.Delete(downloadDirectory + filename);
            File.Move(downloadDirectory + "temp", downloadDirectory + filename);
        }
        // ...
    }
