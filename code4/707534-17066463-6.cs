    // Declare a field to hold the Task
    private static Task DownloadTask;
    private Task Download(string url, string fileName)
    {
        var wc = new WebClient();
        wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
        return wc.DownloadFileTaskAsync(new Uri(url), @"\\10.1.0.15\Symantec Update Weekly\\" + fileName);
    }
    
