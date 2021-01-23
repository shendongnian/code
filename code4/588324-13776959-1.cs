    public class NetworkAdapter
    {
        public string Name {get; set;}
        public string Id  {get; set;}        
        public string Description  {get; set;}
        public string IpAddress  {get; set;}
        public string GatewayIpAddress  {get; set;}
        public string Speed  {get; set;}
        public string NetworkInterfaceType  {get; set;}
        public string MacAddress  {get; set;}
    
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
