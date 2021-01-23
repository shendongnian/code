    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, 
        ServiceHostBase serviceHostBase)
    {
        Type serviceType = serviceDescription.ServiceType;
        IInstanceProvider instanceProvider = new NinjectInstanceProvider(
            new StandardKernel(), serviceType);
 
        foreach(ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
        {
            foreach (EndpointDispatcher endpointDispatcher in dispatcher.Endpoints)
            {
                DispatchRuntime dispatchRuntime = endpointDispatcher.DispatchRuntime;
                dispatchRuntime.InstanceProvider = instanceProvider;
            }
        }
    }
