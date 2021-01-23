      public static void Main()
        {
            try
            {
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher("root\\CIMV2", 
                    "SELECT * FROM Win32_DiskDrive"); 
                foreach (ManagementObject queryObj in searcher.Get())
                {                 
                    Console.WriteLine("SerialNumber: {0}", queryObj["SerialNumber"]);
                    Console.WriteLine("Signature: {0}", queryObj["Signature"]);
                }
            }
            catch (ManagementException e)
            {
                
            }
        }
