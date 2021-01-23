    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    
    namespace GetWMI_Info
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                try
                {
                    List<string> sLookUp = new List<string>();
                    ManagementClass manClass = new ManagementClass("Win32_OperatingSystem");
                    manClass.Options.UseAmendedQualifiers = true;
                    foreach (PropertyData Property in manClass.Properties)
                        if (Property.Name.Equals("OperatingSystemSKU"))                    
                            foreach (QualifierData Qualifier in Property.Qualifiers)
                                if (Qualifier.Name.Equals("Values")) 
                                    foreach (String s in (System.String[])Qualifier.Value)
                                sLookUp.Add(s);                   
                    
    
                    ManagementScope Scope;                
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", "."), null);
                    Scope.Connect();
                    ObjectQuery Query = new ObjectQuery("SELECT OperatingSystemSKU FROM Win32_OperatingSystem");
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
    
                    foreach (ManagementObject WmiObject in Searcher.Get())
                    {
                        Console.WriteLine("{0} {1}", "OperatingSystemSKU", sLookUp[Convert.ToInt32((UInt32)WmiObject["OperatingSystemSKU"])]);// Uint32
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(String.Format("Exception {0} Trace {1}",e.Message,e.StackTrace));
                }
                Console.WriteLine("Press Enter to exit");
                Console.Read();
            }
        }
    }
