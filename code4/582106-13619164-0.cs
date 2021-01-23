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
                    //select the proper wmi namespace depending of the windows version
                    string WMINameSpace = System.Environment.OSVersion.Version.Major > 5 ? "SecurityCenter2" : "SecurityCenter";
     
                    ManagementScope Scope;
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\{1}", "localhost", WMINameSpace), null);
    
                    Scope.Connect();
                    ObjectQuery Query = new ObjectQuery("SELECT * FROM FirewallProduct");
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
    
                    foreach (ManagementObject WmiObject in Searcher.Get())
                    {
                        
                        Console.WriteLine("{0,-35} {1,-40}","Firewall Name",WmiObject["displayName"]);	                    
                        if (System.Environment.OSVersion.Version.Major < 6) //is XP ?
                        {
                        Console.WriteLine("{0,-35} {1,-40}","Enabled",WmiObject["enabled"]);	
                        }
                        else
                        {
                            Console.WriteLine("{0,-35} {1,-40}","State",WmiObject["productState"]);	
                        }   
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
