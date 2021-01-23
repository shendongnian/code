     public class CustomMessageInspector : IClientMessageInspector
        {
            ClientCredentials crendentials = null;
            public CustomMessageInspector(ClientCredentials credentials)
            {
                this.crendentials = credentials;
            }
    
    
            public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
            {
                
            }
    
            public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
            {
                string userName = "";
                string passWord = "";
    
                if (!(crendentials == null))
                {
                    userName = crendentials.UserName.UserName;
                    passWord = crendentials.UserName.Password;
                }
    
               
                return null;
            }
        }
