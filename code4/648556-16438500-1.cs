    using (var listener = new HttpListener())
    {
        listener.Prefixes.Add("http://*:8080/your/service/");
        listener.Start();
    
        Network.Utils.HttpApi.SetRequestQueueLength(listener, 5000);
    
        // ...
    }
