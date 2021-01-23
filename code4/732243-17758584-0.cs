    public void Download(string url, string filenameToSaveAs)
    {
       WebClient wclient = new WebClient();
       wclient.DownloadFileAsync(new Uri(url), filenameToSaveAs);
    }
