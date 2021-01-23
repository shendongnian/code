    public class CustomEndpointBehaviour:IEndpointBehavior
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
                
            }
    
            public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
            {
               ClientCredentials credentials =  endpoint.Behaviors.Find<ClientCredentials>();
    
               clientRuntime.MessageInspectors.Add(new CustomMessageInspector(credentials));
            }
    
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
            {
                
            }
    
            public void Validate(ServiceEndpoint endpoint)
            {
                
            }
        }
