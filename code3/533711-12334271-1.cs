    HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
    req.Method = Constants.HTTPVerbGet;
    req.KeepAlive = false;
    req.Accept = Constants.HTTPRequestType;
    using (var webResponse = (HttpWebResponse)req.GetResponse())
    {
        using (var reader = new StreamReader(webResponse.GetResponseStream()))
        {
            string objJson = reader.ReadToEnd().ToString();
        }
    }
