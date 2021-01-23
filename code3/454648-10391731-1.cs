    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorizeAttribute : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }
    
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase dispatcher in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = dispatcher as ChannelDispatcher;
                if (channelDispatcher != null)
                {
                    foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                    {
                        var inspector = new MessageInspector();
                        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
                    }
                }
            }
    
            //var config = new ServiceLayerConfiguration();
            //config.RequestProcessorImplementation = typeof(PassThruRequestProcessor);
            //config.Initialize();
    
        }
    
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
