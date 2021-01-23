    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    
    namespace GetWMI_Info
    {
        class Program
        {
    // This method is used to format the volume.
    		
            static void Main(string[] args)
            {
                try
                {
                    ManagementScope Scope;                
                    Scope = new ManagementScope("\\\\.\\root\\CIMV2", null);
    
                    Scope.Connect();
                    ObjectGetOptions Options      = new ObjectGetOptions();
                    ManagementPath Path           = new ManagementPath("Win32_Volume.DeviceID=\"\\\\\\\\?\\\\Volume{178edf63-2039-11e2-8012-005056c00008}\\\\\"");
                    ManagementObject ClassInstance= new ManagementObject(Scope, Path, Options);
                    ManagementBaseObject inParams = ClassInstance.GetMethodParameters("Format");
    				
      
                    ManagementBaseObject outParams= ClassInstance.InvokeMethod("Format", inParams ,null);
                    Console.WriteLine("{0,-35} {1,-40}","Return Value",outParams["ReturnValue"]);
    
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
