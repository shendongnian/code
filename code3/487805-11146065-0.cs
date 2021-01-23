    static void PrintInterfaceIndex(string adapterName)
    {
      NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
      IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
    
      Console.WriteLine("IPv4 interface information for {0}.{1}",
                    properties.HostName, properties.DomainName);
    
      foreach (NetworkInterface adapter in nics)
      {               
        if (adapter.Supports(NetworkInterfaceComponent.IPv4) == false)
        {
          continue;
        }
        if (!adapter.Description.Equals(adapterName, StringComparison.OrdinalIgnoreCase))
        {
          continue;
        }
        Console.WriteLine(adapter.Description);                                
        IPInterfaceProperties adapterProperties = adapter.GetIPProperties();                
        IPv4InterfaceProperties p = adapterProperties.GetIPv4Properties();
        if (p == null)
        {
          Console.WriteLine("No information is available for this interface.");                    
          continue;
        }                
        Console.WriteLine("  Index : {0}", p.Index);              
      }
    }
