    using (var client = new JournalProxy())
    {
        var serverUri = new Uri("http://wherever/");
        client.Endpoint.Address = new EndpointAddress(serverUri,
                                                      client.Endpoint.Address.Identity,
                                                      client.Endpoint.Address.Headers);
        // ... use client as usual ...
    }
