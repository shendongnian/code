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
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\OpenHardwareMonitor", "."), null);
    
                    Scope.Connect();
                    ObjectQuery Query = new ObjectQuery("SELECT * FROM Sensor Where Name LIKE 'CPU%'");
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
    
                    foreach (ManagementObject WmiObject in Searcher.Get())
                    {
                        Console.WriteLine("{0,-35} {1,-40}","Identifier",WmiObject["Identifier"]);// String
                        Console.WriteLine("{0,-35} {1,-40}","Index",WmiObject["Index"]);// Sint32
                        Console.WriteLine("{0,-35} {1,-40}","InstanceId",WmiObject["InstanceId"]);// String
                        Console.WriteLine("{0,-35} {1,-40}","Max",WmiObject["Max"]);// Real32
                        Console.WriteLine("{0,-35} {1,-40}","Min",WmiObject["Min"]);// Real32
                        Console.WriteLine("{0,-35} {1,-40}","Name",WmiObject["Name"]);// String
                        Console.WriteLine("{0,-35} {1,-40}","Parent",WmiObject["Parent"]);// String
                        Console.WriteLine("{0,-35} {1,-40}","ProcessId",WmiObject["ProcessId"]);// String
                        Console.WriteLine("{0,-35} {1,-40}","SensorType",WmiObject["SensorType"]);// String
                        Console.WriteLine("{0,-35} {1,-40}","Value",WmiObject["Value"]);// Real32
    	                    
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
