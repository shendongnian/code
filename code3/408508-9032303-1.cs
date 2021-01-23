    WebClient wc = new WebClient();
    for(int i = 1; i < 45 ; i++)
    {
        var pageContent = wc.DownloadString("http://website.com/list/" + i);
        // do your page content processing here
    }
