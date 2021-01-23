    static string GetMacAddress()
    {
      string macAddresses = "";
      foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
      {
        // Find all ethernet MACs
        if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet) 
        {
            macAddresses += nic.GetPhysicalAddress().ToString();
        }
      }
      return macAddresses;
    }
