    long result = 0;
    WebRequest req = WebRequest.Create(url);
    req.Method = "HEAD";
    using (WebResponse resp = req.GetResponse())
    {
        if (long.TryParse(resp.Headers.Get("Content-Length"), out long ContentLength))
        {
            result = ContentLength;
        }
    }
    return result;
}
