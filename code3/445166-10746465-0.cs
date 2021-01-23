    public void PerformLongRunningHubOperation()
    {
        var clients = AspNetHost.DependencyResolver.Resolve<IConnectionManager>().GetClients<MyHub>();
 
        clients.notify("Hello world");
    }
