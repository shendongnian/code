        var binding = ResolveBinding("MyBinding");
        var behaviors = ResolveEndpointBehavior("MyBehavior");
        System.ServiceModel.Description.ContractDescription contract = System.ServiceModel.Description.ContractDescription.GetContract(typeof(IVisService));
         System.ServiceModel.Description.ServiceEndpoint ep = new System.ServiceModel.Description.ServiceEndpoint(contract, binding, "https://some_ip/service.svc");
                        foreach (var behavior in behaviors)
                        {
                            ep.Behaviors.Add(behavior);
                        }
    
    System.ServiceModel.Web.WebChannelFactory<IVisService> t = new System.ServiceModel.Web.WebChannelFactory<IVisService>(ep);
