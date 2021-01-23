    using System.Management;
    
    namespace WMIQuery
    {
      class WmiQuery
      {
        static void Main(string[] args)
        {
          /* On the local computer loged as current user
           */
          ObjectQuery oQuery0 = new ObjectQuery(@"select * from Win32_printer where shared=true");
          ManagementObjectSearcher searcher0 = new ManagementObjectSearcher(oQuery0);
    
          foreach (ManagementObject queryObj in searcher0.Get())
          {
            Console.WriteLine(String.Format("--> {0} ({1})", queryObj["Name"], queryObj["ShareName"]));
          }
        }
      }
    }
