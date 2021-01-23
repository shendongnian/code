    public Stream Load(string term)
    {
        var url = CreateSearchUrl(term);
    
        var webRequest = (HttpWebRequest)WebRequest.Create(url);
        var webResponse = webRequest.GetResponse(); // whoops this doesn't get disposed!
    
        return new GZipStream(webResponse.GetResponseStream(), CompressionMode.Decompress);
    }
