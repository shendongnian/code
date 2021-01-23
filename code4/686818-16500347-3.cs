    private string getResponseBody(HttpMethod method, string partialUrl)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_hostPath + partialUrl);
        req.ContentLength = 0;
        req.KeepAlive = false;
        req.Method = method.ToString();
        using (var response = req.GetResponse())
        using (var stream = response.GetResponseStream())
        using (var reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
