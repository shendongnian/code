    void CreateWebServer()
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://*:8080/");
        listener.Start();
        new Thread(
            () =>
            {
                while (true)
                {
                    HttpListenerContext ctx = listener.GetContext();
                    ThreadPool.QueueUserWorkItem((_) => ProcessRequest(ctx));
                }
            }
        ).Start();
    }
    void ProcessRequest(HttpListenerContext ctx)
    {
        string responseText = "Hello";
        byte[] buf = Encoding.UTF8.GetBytes(responseText);
        Console.WriteLine(ctx.Request.Url);
        ctx.Response.ContentEncoding = Encoding.UTF8;
        ctx.Response.ContentType = "text/html";
        ctx.Response.ContentLength64 = buf.Length;
        ctx.Response.OutputStream.Write(buf, 0, buf.Length);
        ctx.Response.Close();
    }
