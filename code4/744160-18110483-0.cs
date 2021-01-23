     ManagementScope scope;
     SelectQuery query;
     scope = new ManagementScope("root\\WMI");
     query = new SelectQuery("SELECT * FROM WmiMonitorBrightness");
     using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
     {
        using (ManagementObjectCollection objectCollection = searcher.Get())
        {
          foreach (ManagementObject mObj in objectCollection)
          {
            Console.WriteLine(mObj.ClassPath);
            foreach (var item in mObj.Properties)
            {
              Console.WriteLine(item.Name + " " +item.Value.ToString());
              if(item.Name =="CurrentBrightness")
                //Do something with CurrentBrightness
            }
          }
        }
      }
