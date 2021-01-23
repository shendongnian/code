    static void Main(string[] args)
    {
        GlobalHost.DependencyResolver = new NinjectDependencyResolver(Kernel);
        string url = "http://localhost:8081/";
        var server = new Server(url);                        
        // Map the default hub url (/signalr)
        server.MapHubs();
        // Start the server
        server.Start();
