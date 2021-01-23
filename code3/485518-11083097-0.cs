    bool IsImageUrl(string URL)
    {
        var req = (HttpWebRequest)HttpWebRequest.Create(URL);
        req.Method = "HEAD";
        using (var resp = req.GetResponse())
        {
            return resp.ContentType.ToLower().StartsWith("image/");
        }
    }
