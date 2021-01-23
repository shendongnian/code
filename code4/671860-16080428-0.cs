    public NetworkAdapter[] GetAll()
            {
                var networkAdapters = new List<NetworkAdapter>();
    
                foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
                {
                    foreach (UnicastIPAddressInformation uniCast in adapter.GetIPProperties().UnicastAddresses)
                    {
                        if (!System.Net.IPAddress.IsLoopback(uniCast.Address) &&
                            uniCast.Address.AddressFamily != AddressFamily.InterNetworkV6)
                        {
                            GatewayIPAddressInformation lastGatewayAddress = adapter.GetIPProperties().GatewayAddresses.LastOrDefault();
    
                            networkAdapters.Add(new NetworkAdapter()
                                                    {
                                                        Name = adapter.Name,
                                                        ID = adapter.Id,
                                                        Description = adapter.Description,
                                                        IPAddress = uniCast.Address.ToString(),
                                                        NetworkInterfaceType = adapter.NetworkInterfaceType.ToString(),
                                                        Speed = adapter.Speed.ToString("#,##0"),
                                                        MacAddress = getMacAddress(adapter.GetPhysicalAddress().ToString()),
                                                        gatewayIpAddress = string.Join(" ", adapter.GetIPProperties().GatewayAddresses.Select(a => a.Address))
                                                    });
                        }
                    }
                }
    
                return networkAdapters.ToArray();
            }
