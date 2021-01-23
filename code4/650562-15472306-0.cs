         factory = new ChannelFactory<IContract>(binding,
                        new EndpointAddress(address, EndpointIdentity.CreateX509CertificateIdentity(serviceCertificate)));
         factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;
         factory.Credentials.UserName.UserName = "admin";
         factory.Credentials.UserName.Password = "qwerty";
         channel = factory.CreateChannel();
