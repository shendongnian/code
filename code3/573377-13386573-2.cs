    HttpListener listener = new HttpListener();
    listener.Prefixes.Add("http://*:8080/");
    listener.Start();
    Task.Factory.StartNew(() =>
    {
        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            Task.Factory.StartNew((ctx) =>
            {
                WriteFile((HttpListenerContext)ctx);
            }, context,TaskCreationOptions.LongRunning);
        }
    },TaskCreationOptions.LongRunning);
