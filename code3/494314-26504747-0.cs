    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
        foreach (EndpointDispatcher endpointDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>().SelectMany(channelDispatcher => (IEnumerable<EndpointDispatcher>) channelDispatcher.Endpoints))
        {
            if (endpointDispatcher.DispatchRuntime.InstanceProvider == null)
            {
                endpointDispatcher.DispatchRuntime.InstanceProvider = _instanceProviderFactory(serviceDescription.ServiceType);
                endpointDispatcher.DispatchRuntime.MessageInspectors.Add(_requestScopeCleanUp);
            }
       }
    }
