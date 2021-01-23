    serviceHost.Description.Behaviors.Add(new ErrorHandlerBehavior()); //Add your own ErrorHandlerBehaviour
    public class ErrorHandlerBehavior : IErrorHandler, IServiceBehavior
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        public bool HandleError(Exception error)
        {
            if (error is CommunicationException)
            {
                log.Info("Wcf has encountered communication exception.");
            }
            else
            {
                // Log
            }
            return true;
        }
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            //Here you can convert any exception to FaultException like this:
            if (error is FaultException)
                return;
            var faultExc = new FaultException(error.Message);
            var faultMessage = faultExc.CreateMessageFault();
            fault = Message.CreateMessage(version, faultMessage, faultExc.Action);
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, 
            BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                var channelDisp = channelDispatcher as ChannelDispatcher;
                if (channelDisp != null)
                    channelDisp.ErrorHandlers.Add(this);
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
