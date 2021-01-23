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
                        "SELECT * FROM Win32_Product WHERE Name LIKE '%SQL%'"); 
    
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Win32_Product instance");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("InstallDate: {0}", queryObj["InstallDate"]);
                        Console.WriteLine("InstallLocation: {0}", queryObj["InstallLocation"]);
                        Console.WriteLine("Name: {0}", queryObj["Name"]);
                        Console.WriteLine("SKUNumber: {0}", queryObj["SKUNumber"]);
                        Console.WriteLine("Vendor: {0}", queryObj["Vendor"]);
                        Console.WriteLine("Version: {0}", queryObj["Version"]);
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
            }
        }
    }
