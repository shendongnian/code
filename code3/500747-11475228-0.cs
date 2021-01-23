    Parallel.ForEach(urls, url =>
    {
        WebClient Wc = new WebClient();
        string page = Wc.DownloadString(url);
        PrintWebsiteTitle(page, ...);
     });
