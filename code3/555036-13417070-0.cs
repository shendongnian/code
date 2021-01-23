    var factory = new WSTrustChannelFactory(new Microsoft.IdentityModel.Protocols.WSTrust.Bindings.UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential), adfsEndpoint);
    
                factory.Credentials.UserName.UserName = "username";
                factory.Credentials.UserName.Password = "********";
                factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                factory.TrustVersion = TrustVersion.WSTrust13;
                WSTrustChannel channel = null;
                try
                {
                    var rst = new RequestSecurityToken
                    {
                        RequestType = WSTrust13Constants.RequestTypes.Issue,
                        AppliesTo = new EndpointAddress("https://yourserviceendpoint.com/"),
                        KeyType = KeyTypes.Bearer,
                    };
                    channel = (WSTrustChannel)factory.CreateChannel();
                    return channel.Issue(rst);
                }
                catch (Exception e)
                {
                    return null;
                }
