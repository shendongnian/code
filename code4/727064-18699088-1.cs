    namespace Playground.Sandbox
    {
        using System.ServiceModel.Channels;
        using System.ServiceModel.Description;
        using System.ServiceModel.Dispatcher;
        
        public class MyEndpointBehavior : IEndpointBehavior
        {
            public void Validate(
                ServiceEndpoint endpoint)
            {
            }
            
            public void AddBindingParameters(
                ServiceEndpoint endpoint,
                BindingParameterCollection bindingParameters)
            {
            }
            
            public void ApplyDispatchBehavior(
                ServiceEndpoint endpoint,
                EndpointDispatcher endpointDispatcher)
            {
            }
            
            public void ApplyClientBehavior(
                ServiceEndpoint endpoint,
                ClientRuntime clientRuntime)
            {
                var myClientMessageInspector = new MyClientMessageInspector();
                
                clientRuntime.ClientMessageInspectors.Add(myClientMessageInspector);
            }
        }
    }
