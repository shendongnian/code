    public class MyService
    {
        public Result Calc(int i, int j)
        {
            return new Result() { Addition = i + j, Multiplication = i * j };
        }
    }
    public class Result
    {
        public int Addition { set; get; }
        public int Multiplication { set; get; }
    }
    void CreateWebServer()
    {
        MyService service = new MyService();
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://*:8080/");
        listener.Start();
        new Thread(
            () =>
            {
                while (true)
                {
                    HttpListenerContext ctx = listener.GetContext();
                    ThreadPool.QueueUserWorkItem((_) => ProcessRequest(ctx,service));
                }
            }
        ).Start();
    }
    void ProcessRequest(HttpListenerContext ctx,MyService service)
    {
        try
        {
            string responseText = Execute(ctx, service);
            byte[] buf = Encoding.UTF8.GetBytes(responseText);
            ctx.Response.ContentEncoding = Encoding.UTF8;
            ctx.Response.ContentType = "text/html";
            ctx.Response.ContentLength64 = buf.Length;
            ctx.Response.OutputStream.Write(buf, 0, buf.Length);
        }
        catch
        {
            ctx.Response.StatusCode = (int) HttpStatusCode.NotFound;
        }
        ctx.Response.Close();
    }
    string Execute(HttpListenerContext ctx, MyService service)
    {
        System.Collections.Specialized.NameValueCollection nv = HttpUtility.ParseQueryString(ctx.Request.Url.Query);
        MethodInfo mi = service.GetType().GetMethod(nv["method"]);
        object[] parameters =  mi.GetParameters()
                                 .Select(pi => Convert.ChangeType(nv[pi.Name], pi.ParameterType))
                                 .ToArray();
        return JsonConvert.SerializeObject(mi.Invoke(service, parameters));
    }
