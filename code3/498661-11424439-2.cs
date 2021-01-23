    public static void DownloadFile(string url)
    {
        WebClient client = new WebClient();
        var name = url.Substring(url.LastIndexOf('/')).Remove(0, 1);
        client.DownloadFile(url, "C:\\" + name);
    }
