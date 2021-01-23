    public void Load(string term, Action<Stream> action)
    {
        var url = CreateSearchUrl(term);
    
        var webRequest = (HttpWebRequest)WebRequest.Create(url);
        
        using (var webResponse = webRequest.GetResponse())
        using (var responseStream = webResponse.GetResponseStream())
        using (var gzipStream = new GZipStream(responseStream, CompressionMode.Decompress))
        {
            action(gzipStream);
        }
    }
