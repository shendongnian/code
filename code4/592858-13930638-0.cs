                // add the endpoint the router uses to receive messages
                serviceHost.AddServiceEndpoint(
                     typeof(IRequestReplyRouter),
                     new BasicHttpBinding(), 
                     "http://localhost:8000/routingservice/router");
                // create the client endpoint the router routes messages to
                var client = new ServiceEndpoint(
                                                ContractDescription.GetContract(typeof(IRequestReplyRouter)), 
                                                new NetTcpBinding(),
                                                new EndpointAddress("net.tcp://localhost:8008/MyBackendService.svc"));
                // Set SendTimeout, this will be used from the router generated proxy as OperationTimeout
                client.Binding.SendTimeout = new TimeSpan(0, 10, 0);
