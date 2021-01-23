    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using System.ServiceModel.Dispatcher;
    using System.ServiceModel.Channels;
    
    namespace BasicAuth
    {
        public sealed class MessageHttpHeaderInspector : IClientMessageInspector
        {
            #region Private Fields
    
            private string userName;
    
            private string password;
    
            #endregion
    
            #region Constructor
    
            public MessageHttpHeaderInspector(string userName, string password)
            {
                this.userName = userName;
    
                this.password = password;
            }
    
            #endregion
    
            #region IClientMessageInspector Members
    
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                //throw new NotImplementedException();
            }
    
            public object BeforeSendRequest(ref Message request, System.ServiceModel.IClientChannel channel)
            {
                HttpRequestMessageProperty httpRequest;
    
                if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
                {
                    httpRequest = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                }
                else
                {
                    httpRequest = new HttpRequestMessageProperty();
    
                    request.Properties.Add(HttpRequestMessageProperty.Name, httpRequest);
                }
    
                if (httpRequest != null)
                {
                    string credentials = this.CreateBasicAuthenticationCredentials(this.userName, this.password);
    
                    httpRequest.Headers.Add(System.Net.HttpRequestHeader.Authorization, credentials);
                }
    
                return request;
            }
    
            #endregion
    
            #region Private Worker Methods
    
            private string CreateBasicAuthenticationCredentials(string userName, string password)
            {
                string returnValue = string.Empty;
    
                string base64UsernamePassword = Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", userName, password)));
    
                returnValue = String.Format("Basic {0}", base64UsernamePassword);
    
                return returnValue; 
            }
    
            #endregion
        }
    }
