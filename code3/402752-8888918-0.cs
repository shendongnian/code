    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
       foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
       {
             var cd = cdb as ChannelDispatcher;
    
             if (cd != null)
             {
                foreach (var ed in cd.Endpoints)
                {
                   ed.DispatchRuntime.MessageInspectors.Add(new AuthorizationHeaderGetter());
                   ed.DispatchRuntime.InstanceProvider = new UserTokenInjector(serviceDescription.ServiceType);
                }
             }
       }
    }
