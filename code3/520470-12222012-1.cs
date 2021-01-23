    using System;
    using System.Linq;
    using System.Management;
    
    namespace DiskScanPOC
    {
        class Program
        {
            static void Main()
            {
                var managementScope = new ManagementScope();
    
                //get disk drives
                var query = new ObjectQuery("select * from Win32_DiskDrive");
                var searcher = new ManagementObjectSearcher(managementScope, query);
                var oReturnCollection = searcher.Get();
    
                //List all properties available, in case the below isn't what you want.
                var colList = oReturnCollection.Cast<ManagementObject>().First();
                foreach (var property in colList.Properties)
                {
                    Console.WriteLine("Property: {0} = {1}", property.Name, property.Value);
                }
    
                //loop through found drives and write out info
                foreach (ManagementObject oReturn in oReturnCollection)
                {
                    Console.WriteLine("Name : " + oReturn["Name"]);
                    Console.WriteLine("Target Id: " + oReturn["SCSITargetId"]);
                    Console.WriteLine("Port: " + oReturn["SCSIPort"]);
                }
                Console.Read();
            }
        }
    }
