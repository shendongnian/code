    HttpListener listener = new HttpListener();
    listener.Prefixes.Add("http://*:8080/");
    listener.Start();
    Task.Factory.StartNew(() =>
    {
        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            ThreadPool.QueueUserWorkItem((o) =>
            {
                HttpListenerContext ctx = (HttpListenerContext)o;
                StreamReader rdr = new StreamReader(ctx.Request.InputStream);
                var postData = rdr.ReadToEnd();
                var dynJson = (JObject)JsonConvert.DeserializeObject(postData);
                        
                foreach (var ch in dynJson.Children())
                {
                    Console.WriteLine(ch);
                }
                        
            }, context);
        }
    });
    Thread.Sleep(1000);
    WebClient web = new WebClient();
    web.UploadString("http://localhost:8080", 
                      JsonConvert.SerializeObject(new { ID=1,Name="name1" } ));
