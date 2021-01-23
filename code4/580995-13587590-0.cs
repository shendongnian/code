    CookieContainer cookies = new CookieContainer();
    // When using HttpWebRequest or HttpWebResponse, you need to cast for it to work properly
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
    req.CookieContainer = cookies;
    req.ContentType = "application/x-www-form-urlencoded";
    req.Method = "POST";
    byte[] bytes = Encoding.ASCII.GetBytes(Gegevens);
    req.ContentLength = bytes.Length;
    using (Stream os = req.GetRequestStream())
    {
        os.Write(bytes, 0, bytes.Length);
    }
    // Cast here as well
    using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
    {
        // Code related to the web response goes in here
    }
