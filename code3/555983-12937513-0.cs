    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    
    
    namespace GetWMI_Info
    {
        public class EventWatcherAsync 
        {
            private void WmiEventHandler(object sender, EventArrivedEventArgs e)
            {
                Console.WriteLine("TargetInstance.Caption :         " + ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["Caption"]);
                Console.WriteLine("TargetInstance.JobStatus :       " + ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["JobStatus"]);
                Console.WriteLine("TargetInstance.PagesPrinted :    " + ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["PagesPrinted"]);
                Console.WriteLine("TargetInstance.Status :          " + ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["Status"]);
      
            }
    
            public EventWatcherAsync()
            {
                try
                {
                    string ComputerName = "localhost";
                    string WmiQuery;
                    ManagementEventWatcher Watcher;
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
    
                    WmiQuery ="Select * From __InstanceOperationEvent Within 1 "+
                    "Where TargetInstance ISA 'Win32_PrintJob' ";
    
                    Watcher = new ManagementEventWatcher(Scope, new EventQuery(WmiQuery));
                    Watcher.EventArrived += new EventArrivedEventHandler(this.WmiEventHandler);
                    Watcher.Start();
                    Console.Read();
                    Watcher.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception {0} Trace {1}", e.Message, e.StackTrace);
                }
                            
            }
    
            public static void Main(string[] args)
            {
               Console.WriteLine("Listening {0}", "__InstanceOperationEvent");
               Console.WriteLine("Press Enter to exit");
               EventWatcherAsync eventWatcher = new EventWatcherAsync();
               Console.Read();
            }
        }
    }
