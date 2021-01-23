     HakedisServiceClient client = null;
                ChannelEndpointElement endpoint = null;
                ClientSection clientSection = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;              
                ChannelEndpointElementCollection endpointCollection = clientSection.ElementInformation.Properties[string.Empty].Value as ChannelEndpointElementCollection;
                foreach (ChannelEndpointElement endpointElement in endpointCollection)
                {
                    if (endpointElement.Name == "BasicHttpBinding_HakedisService") //BasicHttpBinding_HakedisService from your  config file client endpoint  entries
                    {
                        endpoint = endpointElement;
                    }
                }
                if (endpoint != null)
                {
                    BasicHttpBinding binding = new BasicHttpBinding(endpoint.Name);
                    binding.SendTimeout = TimeSpan.FromMinutes(1); //Set all this as appropriate
                    binding.OpenTimeout = TimeSpan.FromMinutes(1);
                    binding.CloseTimeout = TimeSpan.FromMinutes(1);
                    binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
                    binding.AllowCookies = false;
                    binding.BypassProxyOnLocal = false;
                    binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
                    binding.MessageEncoding = WSMessageEncoding.Text;
                    binding.TextEncoding = System.Text.Encoding.UTF8;
                    binding.TransferMode = TransferMode.Buffered;
                    binding.UseDefaultWebProxy = true;
                    binding.MaxBufferSize = 100000; //as large as needed
                    binding.MaxReceivedMessageSize = 100000; //as large as needed
                    binding.TextEncoding = Encoding.UTF8;
                    System.ServiceModel.EndpointAddress address = new System.ServiceModel.EndpointAddress(endpoint.Address.AbsoluteUri);
                    SSLAccessPolicy.AllowSSLConnection();
                    client = new HakedisServiceClient(binding, address);
					
					SSLAccessPolicy.AllowSSLConnection(); // only if ssl enabled
					client.Open(); // Now open the client socket.
