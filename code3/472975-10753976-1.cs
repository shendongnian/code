    string targetUrl = "http://www.google.com";
    string proxyUrlFormat = "http://zend2.com/bro.php?u={0}&b=12&f=norefer";
    string actualUrl = string.Format(proxyUrlFormat, HttpUtility.UrlEncode(targetUrl));
    
    // Do something with the proxy-ed url
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(actualUrl));
    HttpWebResponse resp = req.GetResponse();
    
    string content = null;
    using(StreamReader sr = new StreamReader(resp.GetResponseStream()))
    {
        content = sr.ReadToEnd();
    }
    
    Console.WriteLine(content);
