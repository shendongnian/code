    using System.Net;
    
    public long GetFileSize(string url)
    {
        long result = 0;
    
        WebRequest req = WebRequest.Create(url);
        req.Method = "HEAD";
        using (WebResponse resp = req.GetResponse())
        {
            if (long.TryParse(resp.Headers.Get("Content-Length"), out long contentLength))
            {
                result = contentLength;
            }
        }
    
        return result;
    }
