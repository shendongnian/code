    private void Download(string url, string downloadDirectory, string fileName)
    {
        WebClient wc = new WebClient();
        wc.Credentials = CredentialCache.DefaultCredentials;
    
        wc.DownloadProgressChanged += DownloadProgress;
        wc.DownloadFileCompleted += DownloadComplete;
        wc.DownloadFileAsync(new Uri(url), downloadDirectory + fileName);
    }
