    public static void SaveHttpResponseAsFile(System.Web.HttpRequestBase requestBase, string requestUrl, string saveFilePath)
    {
        try
        {
            *snip*
            httpRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            httpRequest.Headers.Add(HttpRequestHeader.Cookie, RequestBase.Headers["Cookie"]);
            *snip*</pre></code>
