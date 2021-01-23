    public DisplayClaimCollection GetDisplayClaims(string username, string password)
            {
                WSTrustChannelFactory factory = null;
                try
                {
    
                    // use a UserName Trust Binding for username authentication
                    factory = new WSTrustChannelFactory(
                        new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential),
                        "https://.../adfs/services/trust/13/usernamemixed");
    
                    factory.TrustVersion = TrustVersion.WSTrust13;
    
    
                    factory.Credentials.UserName.UserName = username;
                    factory.Credentials.UserName.Password = password;
    
    
                    var rst = new RequestSecurityToken
                                  {
                                      RequestType = RequestTypes.Issue,
                                      AppliesTo = "Relying party endpoint address",
                                      KeyType = KeyTypes.Symmetric,
                                      RequestDisplayToken = true
                                  };
    
                    IWSTrustChannelContract channel = factory.CreateChannel();
                    RequestSecurityTokenResponse rstr;
                    SecurityToken token = channel.Issue(rst, out rstr);
    
                    return rstr.RequestedDisplayToken.DisplayClaims;
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
