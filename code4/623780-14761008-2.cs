    void Main()
    {
        Task.Factory.StartNew(() => Listener());
        _blocker.WaitOne();
        Request();
    }
    
    public bool _running;
    public ManualResetEvent _blocker = new ManualResetEvent(false);
    
    public void Listener()
    {
        var listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8080/");
        listener.Start();
        "Listener is listening...".Dump();;
        _running = true;
        _blocker.Set();
        var ctx = listener.GetContext();
        "Listener got context".Dump();
        ctx.Response.KeepAlive = true;
        ctx.Response.ContentType = "application/json";
        var outputStream = ctx.Response.OutputStream;
        using(var zipStream = new GZipStream(outputStream, CompressionMode.Compress))
        using(var writer = new StreamWriter(outputStream))
        {
            var lineCount = 0;
            while(_running && lineCount++ < 10)
            {
                writer.WriteLine("{ \"foo\": \"bar\"}");
                "Listener wrote line, taking a nap...".Dump();
                writer.Flush();
                Thread.Sleep(1000);
            }
        }
        listener.Stop();
    }
    
    public void Request()
    {
        var endPoint = "http://localhost:8080";
        var username = "";
        var password = "";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
        request.Method = "GET";
        
        request.PreAuthenticate = true;
        request.Credentials = new NetworkCredential(username, password);
        
        request.AutomaticDecompression = DecompressionMethods.GZip;
        request.ContentType = "application/json";
        request.Accept = "application/json";
        request.Timeout = 30;
        request.BeginGetResponse(AsyncCallback, request);
    }
    
    public void AsyncCallback(IAsyncResult result)
    {
        Console.WriteLine("In AsyncCallback");    
        HttpWebRequest request = result.AsyncState as HttpWebRequest;    
        using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result))
        using (Stream stream = response.GetResponseStream())
        {
            while(stream.CanRead)
            {
                var buffer = new byte[2048];
                var readCount = stream.Read(buffer, 0, buffer.Length);
                var line = Encoding.UTF8.GetString(buffer.Take(readCount).ToArray());
                Console.WriteLine("Reader got:" + line);
            }
        }
    }
