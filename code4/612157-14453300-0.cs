    WebClient wclient = new WebClient();
    wclient.DownloadStringAsync(new Uri("url of your xml"));
    wclient.DownloadStringCompleted += FilesIsCompleted;
    private void FilesIsCompleted(object sender, DownloadStringCompletedEventArgs e)
     {
    
        XDocument xdoc = XDocument.Parse(e.Result, LoadOptions.None);
    
     }
