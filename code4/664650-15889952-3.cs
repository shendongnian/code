    public override void ProcessRequest(IHttpRequest httpReq, IHttpResponse httpRes, string operationName)
    {
        var bytes = File.ReadAllBytes(fi.FullName);                   
        httpRes.AddHeader("Date", DateTime.Now.ToString("R"));
        httpRes.AddHeader("Content-Type", "text/plain");
        httpRes.AddHeader("TestHeader", "SomeValue");
        httpRes.OutputStream.Write(bytes, 0, bytes.Length);
    }
