    public static DateTime GetNistTime()
    {
        DateTime dt = DateTime.MinValue;
    
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://....");
        req.Method = "GET";
        req.Accept = "text/html, application/xhtml+xml, */*";
        req.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
        req.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore); //No caching
        HttpWebResponse res = (HttpWebResponse)req.GetResponse();
        if (res.StatusCode == HttpStatusCode.OK)
        {
            StreamReader st = new StreamReader(res.GetResponseStream());
            string html = st.ReadToEnd().ToUpper();
            string time = Regex.Match(html, @">\d+:\d+:\d+<").Value; //HH:mm:ss format
            string date = Regex.Match(html, @">\w+,\s\w+\s\d+,\s\d+<").Value; //dddd, MMMM dd, yyyy
            dt= DateTime.Parse((date + " " + time).Replace(">", "").Replace("<", ""));
        }
    
        return dt;
    }
