        public SecurityToken GetToken(out RequestSecurityTokenResponse rstr)
        {
            Console.WriteLine("Connecting to STS...");
            WSTrustChannelFactory factory = null;
            try
            {
                if (_useCredentials)
                {
                    // use a UserName Trust Binding for username authentication
                    factory =
                        new WSTrustChannelFactory(
                            new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential),
                            "https://<adfs>/adfs/services/trust/13/UsernameMixed");
                    factory.TrustVersion = TrustVersion.WSTrust13;
                    // Username and Password here...
                    factory.Credentials.UserName.UserName = "username";
                    factory.Credentials.UserName.Password = "password";
                }
                else
                {
                    // Windows authentication over transport security
                    factory = new WSTrustChannelFactory(
                        new WindowsWSTrustBinding(SecurityMode.Transport),
                        "https://<adfs>/adfs/services/trust/13/windowstransport") { TrustVersion = TrustVersion.WSTrust13 };
                }
                var rst = new RequestSecurityToken
                              {
                                  RequestType = RequestTypes.Issue,
                                  AppliesTo = SvcEndpoint,
                                  KeyType = KeyTypes.Symmetric,
                                  RequestDisplayToken = true
                              };
                Console.WriteLine("Creating channel for STS...");
                IWSTrustChannelContract channel = factory.CreateChannel();
                 Console.WriteLine("Requesting token from " + StsEndpoint.Uri);
                 SecurityToken token = channel.Issue(rst, out rstr);
                 Console.WriteLine("Received token from " + StsEndpoint.Uri);
                return token;
            }
            finally
            {
                if (factory != null)
                {
                    try
                    {
                        factory.Close();
                    }
                    catch (CommunicationObjectFaultedException)
                    {
                        factory.Abort();
                    }
                }
            }
        }
