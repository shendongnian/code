    public class ServiceFactory : WebServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost host = new RestServiceHost(typeof(Service), baseAddresses);
            host.AddServiceEndpoint(serviceType, new WebHttpBinding(), baseAddresses[0]);
            return host;
        }
    }
    public class RestServiceHost : WebServiceHost
    {
        public RestServiceHost() : base() { }
        public RestServiceHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses) { }
        protected override void OnOpening()
        {
            base.OnOpening();
            foreach (var endpoint in base.Description.Endpoints)
            {
                if (endpoint.Behaviors.Find<ServiceBehavior>() == null)
                {
                    endpoint.Behaviors.Add(new ServiceBehavior());
                }
            }
        }
    }
    public class ServiceBehavior : WebHttpBehavior
    {
        protected override void AddServerErrorHandlers(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Clear();
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new ServiceErrorHandler());
        }
    }
    public class ServiceErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return true;
        }
        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            Utils.HandleException(error, true);
        }
    }
