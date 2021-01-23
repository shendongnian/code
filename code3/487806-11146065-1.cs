    ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
           
    ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter WHERE Description='<Your Network Adapter name goes here>'");           
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
    {
      using (ManagementObjectCollection queryCollection = searcher.Get())
      {             
        foreach (ManagementObject mo in queryCollection)
        {                 
          Console.WriteLine("InterfaceIndex : {0}, name {1}", mo["InterfaceIndex"], mo["Description"]);
        }
      }
    }
