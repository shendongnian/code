    HttpListener listener = new HttpListener();
    listener.Prefixes.Add("http://*:8080/");
    listener.Start();
    while (true)
    {
        HttpListenerContext ctx = listener.GetContext();
        ThreadPool.QueueUserWorkItem((_) =>
        {
            StreamReader rdr = new StreamReader(ctx.Request.InputStream);
            var postData = rdr.ReadToEnd();
            var json =  JsonConvert.DeserializeObject(postData);
            Console.WriteLine(postData);
        });
    }
