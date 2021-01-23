       public class MyBehaviour : IEndpointBehavior
    {     
   
        public void AddBindingParameters(ServiceEndpoint endpoint,
           System.ServiceModel.Channels.BindingParameterCollection
                                                bindingParameters)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
           
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            var inspector = new SampleMessageInspector(); //register
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
        
    }
