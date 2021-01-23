    var client = channelFactory.CreateChannel<IRestClient>(); // whatever bindings I'd need for this
    
        System.ServiceModel.Description.WebHttpBehavior behaviour = new System.ServiceModel.Description.WebHttpBehavior();
        behaviour.DefaultOutgoingRequestFormat = System.ServiceModel.Web.WebMessageFormat.Json;
        behaviour.DefaultOutgoingResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json;
        client.Endpoint.Behaviors.Add(behaviour);
        m_Proxy = client.CreateChannel();
    
    
    var response = m_Proxy.Authorize("abc", "def", 123);
