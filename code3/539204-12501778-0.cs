    public void DoSomething(string test)
    { 
        // Get HubB's ConnectionId given HubA's ConnectionId (implementation left to you)
        string hubBConnectionId = MapHubAConnectionIdToHubBConnectionId(Context.ConnectionId);
        // Get the context for HubB
        var hubBContext = GlobalHost.ConnectionManager.GetHubContext<HubB>();
        // Invoke the method for just the current caller on HubB
        hubBContext.Clients[hubBConnectionId].messageHandler(test); 
    }
