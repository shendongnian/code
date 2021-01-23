    public static bool Ping(string url, string actualTargetEnpoint)
    {
        var uri = new UriBuilder(url);
        // take note of the original host to use for the "Host" header
        var originalHost = uri.Host;
        // swap out the actual endpoint we are going to be hitting
        uri.Host = actualTargetEnpoint;
        var req = (HttpWebRequest)WebRequest.Create(uri.ToString());
        // replace the host header on the request for the originally supplied target
        req.Host = originalHost;
        var response = (HttpWebResponse)req.GetResponse();
        return response.StatusCode == HttpStatusCode.OK;
    }
