        // Get the value of the hidden from the request
        string currentClientConnectionId = Request.Form["SignalRConnectionId"];
        // Get the hub context
        IHubContext myHubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        // Resolve a the client that corresponds to the current request
        dynamic currentClient = myHubContext.Client(currentClientConnectionId);
