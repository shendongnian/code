    //This is run on it's own thread
    HttpListener listener = new HttpListener();
    listener.Prefixes.Add(Properties.Settings.Default.BitsReplierAddress);
    listener.Start();
    while (_running)
    {
        // Note: The GetContext method blocks while waiting for a request. 
        // Could be done with BeginGetContext but I was having trouble 
        // cleanly shutting down
        HttpListenerContext context = listener.GetContext();
        HttpListenerRequest request = context.Request;
        var requestUrl = request.Headers["BITS-Original-Request-URL"];
        var requestDatafileName = request.Headers["BITS-Request-DataFile-Name"];
        //(Snip...) Deal with the file that was uploaded
    }
    listener.Stop();
