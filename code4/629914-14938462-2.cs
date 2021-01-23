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
                  string strSearchText="win";
                  string strSearchQuery=string.Format("SELECT * FROM Win32_Service where Name like '%{0}%'",strSearchText);
                  ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",strSearchQuery  );
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_Service instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Name: {0}", queryObj["Name"]);
                }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
            }
        }
    }
