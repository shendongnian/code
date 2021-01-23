    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    
    namespace GetWMI_Info
    {
        class Program
        {
    
            static string GetKeyField(string WmiCLass)
            {
                string key = null; 
                ManagementClass manClass = new ManagementClass(WmiCLass);
                manClass.Options.UseAmendedQualifiers = true;
                foreach (PropertyData Property in manClass.Properties)
                    foreach (QualifierData Qualifier in Property.Qualifiers)
                        if (Qualifier.Name.Equals("key") && ((System.Boolean)Qualifier.Value))                        
                            return Property.Name;
                return key;                                                    
            }
    
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine(String.Format("The Key field of the WMI class {0} is {1}", "Win32_DiskPartition", GetKeyField("Win32_DiskPartition")));
                    Console.WriteLine(String.Format("The Key field of the WMI class {0} is {1}", "Win32_Process", GetKeyField("Win32_Process")));
                }
                catch (Exception e)
                {
                    Console.WriteLine(String.Format("Exception {0} Trace {1}", e.Message, e.StackTrace));
                }
                Console.WriteLine("Press Enter to exit");
                Console.Read();
            }
        }
    }
