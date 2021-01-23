    private List<string> urls = new List<string>();
    private void btnGo_Click(object sender, EventArgs e)
    {
        urls.Add("http://www.google.com/");
        urls.Add("http://www.yahoo.com/");
        urls.Add("http://www.amazon.com/");
        Parallel.ForEach(urls, new ParallelOptions { MaxDegreeOfParallelism = 10 }, DownloadFile);
    }
    public static void DownloadFile(string url)
    {
        var req = (HttpWebRequest)WebRequest.Create(url);
        var name = url.Substring(url.LastIndexOf('/')).Remove(0, 1);
        using (var res = (HttpWebResponse)req.GetResponse())
        using (var resStream = res.GetResponseStream())
        using (var fs = new FileStream("C:\\" + name, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            // Save to file
            var buffer = new byte[8 * 1024]; // 8 KB buffer
            int len; // Read count
            while ((len = resStream.Read(buffer, 0, buffer.Length)) > 0)
                fs.Write(buffer, 0, buffer.Length);
        }
    }
