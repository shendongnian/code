    using (var mc = new ManagementClass(@"\\" + computerName + @"\root\cimv2:Win32_OperatingSystem"))
    {
        foreach (var obj in mc.GetInstances())
        {
           if (((bool)obj.Properties["Primary"].Value))
           {
              int productType = (int)obj.Properties["ProductType"].Value;
              string version = obj.Properties["Version"].Value.ToString();
              bool isServer = (productType == 2 || productType == 3); // "Domain Controller" or "Server
              if (version == "5.2.3790" && isServer)
              {
                 // "Caption" should contain something like "Microsoft(R) Windows(R) Server 2003..."
                 // Please resist parsing that, however.                  
                 Console.WriteLine(obj.Properties["Caption"].Value);
              }
           }
        }
     }
