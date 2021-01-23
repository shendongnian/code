    public static void DownloadFile(string url)
    {
        var req = (HttpWebRequest)WebRequest.Create(url);
        using (var res = (HttpWebResponse)req.GetResponse())
        using (var resStream = res.GetResponseStream())
        {
            // Do what you want with the data here
            Console.WriteLine("Output received for: " + url);
        }
    }
