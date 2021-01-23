    using System;
    using System.Management;
    namespace WMISample
    {
        public class MyWMIQuery
        {
            public static void Main()
            {             
                try
                {
                    ManagementClass osClass = new ManagementClass("Win32_OperatingSystem");
                    foreach (ManagementObject queryObj in osClass.GetInstances())
                    {
                        foreach (PropertyData prop in queryObj.Properties)
                        {
                            //add these to your arraylist or dictionary 
                          Console.WriteLine("{0}: {1}", prop.Name, prop.Value);
                        }                    
                    }
                }
                catch (ManagementException e)
                {
                    //MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
            }
        }
    }
