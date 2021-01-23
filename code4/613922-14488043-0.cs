    private void Test()
    {
        string pageData = DownloadWebPage(new Uri("http://www.yourftp.com"));
        //parse data
    }
    
    private string DownloadWebPage(Uri path)
    {
        string webPageData = null;
    
        using (WebClient client = new WebClient())
        {
            client.DownloadStringAsync(path);
            client.DownloadStringCompleted += (sender, args) => webPageData = args.Result;
        }
    
        return webPageData;
    }
