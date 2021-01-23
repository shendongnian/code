    public void ProcessRequest(HttpContext context)
    {
        string method = context.Request.QueryString["method"].ToString().ToLower();
        
        if (method == "MyMethod1")
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(CallWebService(method, param));
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
        else if (method == "MyMethod2")
        {
            context.Response.ContentType = "text/plain";
            string param = "myparam";
            context.Response.Write(CallWebService(method, param));
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
        else
        {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        }
        
    }
    private string CallWebService(string method, string param)
    {
        string ServeurURL = "https://myserver.com"; 
        System.Net.WebRequest req = System.Net.WebRequest.Create(ServeurURL + method);
        req.Method = "POST";
        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(param);
        req.ContentType = "text/xml";
        req.ContentLength = byteArray.Length;
        System.IO.Stream reqstream = req.GetRequestStream();
        reqstream.Write(byteArray, 0, byteArray.Length);
        reqstream.Close();
        System.Net.WebResponse wResponse = req.GetResponse();
        reqstream = wResponse.GetResponseStream();
        System.IO.StreamReader reader = new System.IO.StreamReader(reqstream);
        string responseFromServer = reader.ReadToEnd();
        return responseFromServer;
    }
