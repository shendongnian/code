    public class XInstanceProviderServiceBehavior : Attribute, IServiceBehavior
    {        
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var item in serviceHostBase.ChannelDispatchers)
            {
                var dispatcher = item as ChannelDispatcher;
                if (dispatcher != null) 
                {
                    dispatcher.Endpoints.ToList().ForEach(endpoint =>
                    {
                        endpoint.DispatchRuntime.InstanceProvider = new XInstanceProvider(serviceDescription.ServiceType);
                    });
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }
    }
