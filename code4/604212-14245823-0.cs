        WCFServiceClient client = new WCFServiceClient();
    #if DEBUG
        client.Endpoint.Address = new EndpointAddress(new Uri("http://devSrv/WCFService.svc"));
        client.Endpoint.Name = "Dev";
    #else
        client.Endpoint.Address = new EndpointAddress(new Uri("http://prodSrv/WCFService.svc"));
        client.Endpoint.Name = "Prod";
    #endif
