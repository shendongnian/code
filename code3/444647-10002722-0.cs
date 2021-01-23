    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    //this will all the notepad running instances
    
    namespace GetWMI_Info
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    string ComputerName = "localhost";
                    ManagementScope Scope;                
    
                    if (!ComputerName.Equals("localhost", StringComparison.OrdinalIgnoreCase)) 
                    {
                        ConnectionOptions Conn = new ConnectionOptions();
                        Conn.Username  = "";
                        Conn.Password  = "";
                        Conn.Authority = "ntlmdomain:DOMAIN";
                        Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), Conn);
                    }
                    else
                        Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
    
                    Scope.Connect();
                    ObjectQuery Query = new ObjectQuery("SELECT Handle FROM Win32_Process Where Name='notepad.exe'");
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
    
                    foreach (ManagementObject WmiObject in Searcher.Get())
                    {
                        WmiObject.InvokeMethod("Terminate", null);
    	                    
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
