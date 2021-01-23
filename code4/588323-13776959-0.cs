    public class NetworkAdapter
    {
        public string Name {get; set;};
        public string Id;        
        public string Description;
        public string IpAddress;
        public string GatewayIpAddress;
        public string Speed;
        public string NetworkInterfaceType;
        public string MacAddress;
    
        public IEnumerable<NetworkAdapter> getAdapterInfo()
        {
            NetworkAdapter na = null;
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                IPInterfaceProperties properties = adapter.GetIPProperties(); //fetch network configuration properties
                foreach (IPAddressInformation uniCast in properties.UnicastAddresses)
                {
                    if (!IPAddress.IsLoopback(uniCast.Address) && uniCast.Address.AddressFamily != AddressFamily.InterNetworkV6) //ignore loop-back addresses & IPv6 internet protocol family
                    {
                        na = new NetworkAdapter{ 
                        Name = adapter.Name;
                        Id= adapter.Id;
                        Description= adapter.Description;
                        IpAddress= uniCast.Address.ToString();
                        GatewayIpAddress= adapter.NetworkInterfaceType.ToString();
                        Speed= adapter.Speed.ToString("#,##0");
    
                        NetworkInterfaceType = adapter.GetPhysicalAddress().ToString();
                        };
  
                        foreach (GatewayIPAddressInformation gatewayAddress in adapter.GetIPProperties().GatewayAddresses)
                        {
                            _gatewayIpAddress = gatewayAddress.Address.ToString();
                        }
                    }
                }
            }
    
            yield return na ;
        }
    }
