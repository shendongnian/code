    using System;
    using System.Management;
    using System.Windows.Forms;
     
    namespace WMISample
    {
        public class MyWMIQuery
        {
            public static void Main()
            {
                try
                {
                    ManagementObjectSearcher searcher = 
                        new ManagementObjectSearcher("root\\CIMV2", 
                        "SELECT * FROM Win32_OperatingSystem WHERE ProductType = 2"); 
 
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_OperatingSystem instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("ProductType: {0}", queryObj["ProductType"]);
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }
    }
