    HttpListener listener = new HttpListener();
    listener.Prefixes.Add("http://*:8080/");
    listener.Start();
    while (true)
    {
        HttpListenerContext context = listener.GetContext();
        ThreadPool.QueueUserWorkItem((o) =>
        {
            HttpListenerContext ctx = (HttpListenerContext)o;
            StreamReader rdr = new StreamReader(ctx.Request.InputStream);
            var postData = rdr.ReadToEnd();
            var dynJson =  JsonConvert.DeserializeObject(postData);
            Console.WriteLine(postData);
        }, context);
    }
