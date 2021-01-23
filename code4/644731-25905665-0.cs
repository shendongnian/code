                WS2007HttpBinding binding = new WS2007HttpBinding(SecurityMode.TransportWithMessageCredential);
                binding.Security.Message.EstablishSecurityContext = false;               
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                if (isWindowsUser)
                {
                    binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
                    ep = new EndpointAddress("https://abc.com/adfs/services/trust/13/windowsmixed");                    
                }
                else
                {
                    binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
                    ep = new EndpointAddress("https://abc.com/adfs/services/trust/13/usernamemixed");                    
                }
                factory = new WSTrustChannelFactory(binding, ep);
                factory.TrustVersion = TrustVersion.WSTrust13;
             
                    factory.Credentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;                     
               
               
                var rst = new RequestSecurityToken
                {
                    RequestType = RequestTypes.Issue,
                    AppliesTo = new EndpointReference("urn:adfsmonitor"),
                    KeyType = KeyTypes.Bearer,
                };
                IWSTrustChannelContract channel = factory.CreateChannel();
                GenericXmlSecurityToken genericToken = channel.Issue(rst)
                 as GenericXmlSecurityToken;
                return genericToken.TokenXml.InnerXml.ToString();
