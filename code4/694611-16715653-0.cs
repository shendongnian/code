    var address = CommonMethods.GetIpLocalAddress();
                _host = new ServiceHost(typeof(AgentService), new Uri(string.Format("net.tcp://{0}/AgentService", address)));
                
                var endpoint = _host.AddServiceEndpoint(typeof(IAgent), new NetTcpBinding(), String.Empty);
                var metadataProvider = new CiscoMetaDataProvider();
                var discoveryBehavior = new EndpointDiscoveryBehavior();
                discoveryBehavior.Scopes.Add(new Uri("net.tcp://blablabla.com/CallTesting/AgentService/1/Cisco"));
                discoveryBehavior.Extensions.Add(new XElement("phoneNumber", metadataProvider.GetPhoneNumber()));
                endpoint.Behaviors.Add(discoveryBehavior);
                var discoveryEndpoint = new UdpDiscoveryEndpoint();
                _host.AddServiceEndpoint(discoveryEndpoint);
                ServiceDiscoveryBehavior serviceDiscoveryBehavior = new ServiceDiscoveryBehavior();
                serviceDiscoveryBehavior.AnnouncementEndpoints.Add(new UdpAnnouncementEndpoint());
                _host.Description.Behaviors.Add(serviceDiscoveryBehavior);
                _host.Open();
