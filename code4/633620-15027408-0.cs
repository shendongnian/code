    // create bindings & endpoints
    var baseAddress = System.ConfigurationManager.AppSettings["baseAddress"];
    var binding = new System.ServiceModel.BasicHttpBinding();
    var endpoint = new EndpointAddress(baseAddress + "/ServiceX.svc");
    
