    [HttpPut]
    public void TellUsers(string msg)
    {
       var connectionManager = AspNetHost.DependencyResolver.Resolve<IConnectionManager>();
       var demoClients = connectionManager.GetClients<MyHubDerivedClass>();
       demoClients.TellUsers(msg);
    }
