    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Web;
    
    namespace MyCustomExtensionService
    {
        public class MyCustomAttributeBehavior : IEndpointBehavior
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
                //throw new NotImplementedException();
            }
    
            public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
            {
                foreach (ClientOperation clientOperation in clientRuntime.Operations)
                {
                    clientOperation.ParameterInspectors.Add(
                        new MyParameterInspector());
                }
            }
    
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
            {
                foreach (DispatchOperation dispatchOperation in endpointDispatcher.DispatchRuntime.Operations)
                {
    
                    dispatchOperation.ParameterInspectors.Add(
                        new MyParameterInspector());
                }
            }
    
            public void Validate(ServiceEndpoint endpoint)
            {
                //throw new NotImplementedException();
            }
        }
    }
