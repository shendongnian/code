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
                    string ComputerName = "localhost";//set the remote machine name here
                    ManagementScope Scope;                
    
                    if (!ComputerName.Equals("localhost", StringComparison.OrdinalIgnoreCase)) 
                    {
                        ConnectionOptions Conn = new ConnectionOptions();
                        Conn.Username  = "";//user
                        Conn.Password  = "";//password
                        Conn.Authority = "ntlmdomain:DOMAIN";
                        Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), Conn);
                    }
                    else
                        Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
    
                    Scope.Connect();
                    ObjectQuery Query = new ObjectQuery("SELECT * FROM Win32_CDROMDrive");
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
    
                    foreach (ManagementObject WmiObject in Searcher.Get())
                    {
                        Console.WriteLine("{0,-35} {1,-40}","DeviceID",WmiObject["DeviceID"]);// String
                        Console.WriteLine("{0,-35} {1,-40}","Drive",WmiObject["Drive"]);// String
    	                    
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
