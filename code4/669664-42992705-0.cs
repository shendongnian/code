    var cl = new ActiveDirectoryClient();
     
    var eab = new EndpointAddressBuilder(cl.Endpoint.Address);
     
    eab.Headers.Add( AddressHeader.CreateAddressHeader("ClientId",       // Header Name
                                                       string.Empty,     // Namespace
                                                        "OmegaClient")); // Header Value
    cl.Endpoint.Address = eab.ToEndpointAddress();
     
    // Now do an operation provided by the service.
    cl.ProcessInfo("ABC");
