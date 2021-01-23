     ServiceCallback serviceCallback = new ServiceCallback();
     InstanceContext instanceContext = new InstanceContext(serviceCallback);
    
     var pubsubProxy = new PubSubProxy.WcfPublisherContractClient(instanceContext);
     pubsubProxy.Subscribe();
