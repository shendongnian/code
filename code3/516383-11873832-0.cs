    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    
    namespace GetWMI_Info
    {
        class Program
        {
    
            public static void  Defrag(string a_DriveName)
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
                    string WQL = String.Format("SELECT * FROM Win32_Volume Where Name='{0}'", a_DriveName);
                    ObjectQuery Query = new ObjectQuery(WQL);
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
    
                    foreach (ManagementObject ClassInstance in Searcher.Get())
                    {
                    ManagementBaseObject inParams = ClassInstance.GetMethodParameters("Defrag");
                    ManagementBaseObject outParams= ClassInstance.InvokeMethod("Defrag", inParams ,null);
                    Console.WriteLine("{0,-35} {1,-40}","DefragAnalysis",outParams["DefragAnalysis"]);
                    Console.WriteLine("{0,-35} {1,-40}","ReturnValue",outParams["ReturnValue"]);                
                    }
                   			
                }
                catch (Exception e)
                {
                    Console.WriteLine(String.Format("Exception {0} Trace {1}",e.Message,e.StackTrace));
                }
            
            
            
            }
    
    		
            static void Main(string[] args)
            {
                //the drive name  must be escaped 
                Defrag("F:\\\\");
                Console.WriteLine("Press Enter to exit");
                Console.Read();
            }
        
    }
