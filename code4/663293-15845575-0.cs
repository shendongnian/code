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
                    ManagementScope Scope;                
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", "."), null);
                    Scope.Connect();
                    ObjectQuery Query = new ObjectQuery("SELECT * FROM Win32_Volume Where DriveLetter='X:' ");
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
                    if (Searcher.Get().Count==0)                
                    {
                        Console.WriteLine("Do something, when the collection is empty.");                
                    }
                    else
                    foreach (ManagementObject WmiObject in Searcher.Get())
                    {
                        Console.WriteLine("{0} {1}","Name",WmiObject["Name"]);// String
    	                    
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
