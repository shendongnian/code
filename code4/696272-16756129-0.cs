    private void Download(string url, string downloadDirectory)
    {
        using(WebClient wc = new WebClient())
        {
            string filename = FilenameFromURL(url);
    
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadComplete);
    
            wc.DownloadFileAsync(new Uri(url), downloadDirectory + filename);
        }
    }
