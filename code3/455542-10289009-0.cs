    /// <summary>
    ///   Custom WCF Behaviour for Service Level Exception handling.
    /// </summary>
    public class ErrorHandlerBehavior : IServiceBehavior
        {
        #region Implementation of IServiceBehavior
        public void Validate (ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
            {
            }
        public void AddBindingParameters (ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
                                          Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
            {
            }
        
        public void ApplyDispatchBehavior (ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
            {
            IErrorHandler errorHandler = new ErrorHandler ();
            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
                {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                if (channelDispatcher != null)
                    {
                    channelDispatcher.ErrorHandlers.Add (errorHandler);
                    }
                }
            }
        #endregion
        }
