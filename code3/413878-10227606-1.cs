    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    
    namespace BasicAuth
    {
        public sealed class CustomEndpointCallBehavior : IEndpointBehavior
        {
            #region Private Fields
    
            private string userName;
    
            private string password;
    
            #endregion
    
            #region Constructor
    
            public CustomEndpointCallBehavior(string userName, string password)
            {
                this.userName = userName;
    
                this.password = password;
            }
    
            #endregion
    
            #region IEndpointBehavior Members
    
            public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
                //throw new NotImplementedException();
            }
    
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                clientRuntime.MessageInspectors.Add(new MessageHttpHeaderInspector(this.userName, this.password));
            }
    
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                //throw new NotImplementedException();
            }
    
            public void Validate(ServiceEndpoint endpoint)
            {
                //throw new NotImplementedException();
            }
    
            #endregion
        }
    }
