    class ErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
       Type errorHandlerType;
    
       public ErrorBehaviorAttribute(Type errorHandlerType)
       {
          this.errorHandlerType = errorHandlerType;
       }
    
       public void Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
       {
       }
    
       public void AddBindingParameters(ServiceDescription description, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)
       {
       }
    
       public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
       {
          IErrorHandler errorHandler;
    
          errorHandler = (IErrorHandler)Activator.CreateInstance(errorHandlerType);
          foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
          {
             ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
             channelDispatcher.ErrorHandlers.Add(errorHandler);
          }
       }
    }
