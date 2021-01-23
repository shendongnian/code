    ManagementObjectSearcher query = 
        new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration  WHERE DHCPEnabled ='TRUE'");
    ManagementObjectCollection queryCollection = query.Get();
    queryCollection = query.Get();
    foreach (ManagementObject currentConfig in queryCollection)
    {
      string[] addresses = (string[])currentConfig["IPAddress"];
      Console.Out.WriteLine(currentConfig["Description"]);
      if (addresses != null)
      {
        foreach (var addr in addresses)
        {
          Console.Out.WriteLine(addr);
        }
      }
    }
