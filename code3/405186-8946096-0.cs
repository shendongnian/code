    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Management.ObjectQuery query = new ObjectQuery("Select * FROM Win32_Battery");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
    
                ManagementObjectCollection collection = searcher.Get();
    
                foreach (ManagementObject mo in collection)
                {
                    foreach (PropertyData property in mo.Properties)
                    {
                        Console.WriteLine("Property {0}: Value is {1}", property.Name, property.Value);
                    }                   
                }
            }
        }
    }
