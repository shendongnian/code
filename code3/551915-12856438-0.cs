            .Register(
                Component
                .For<MyNamespace.ContractInterface>()
                .ImplementedBy<MyNamespace.ImplementationClass>()
                .Named("ServiceName").LifestylePerWcfOperation()
                .AsWcfService(
                    new DefaultServiceModel().Hosted().AddEndpoints(
                        WcfEndpoint.BoundTo(new BasicHttpBinding { 
                            Security = new BasicHttpSecurity { 
                                Mode = (WebConfigurationManager.AppSettings["Service.WCFFacility.TransportMode"] == "http") ? BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport, 
                                Transport = new HttpTransportSecurity { 
                                    ClientCredentialType = HttpClientCredentialType.None 
                                } 
                            }
                        }).At(WebConfigurationManager.AppSettings["Service.WCFFacility.Endpoint"])
                    )
                )
            );
