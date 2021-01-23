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
                Console.WriteLine("Active :          " + e.NewEvent.Properties["Active"].Value.ToString());
                Console.WriteLine("Brightness :      " + e.NewEvent.Properties["Brightness"].Value.ToString());
                Console.WriteLine("InstanceName :    " + e.NewEvent.Properties["InstanceName"].Value.ToString());
      
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
                        Scope = new ManagementScope(String.Format("\\\\{0}\\root\\WMI", ComputerName), Conn);
                    }
                    else
                        Scope = new ManagementScope(String.Format("\\\\{0}\\root\\WMI", ComputerName), null);
                    Scope.Connect();
    
                    WmiQuery ="Select * From WmiMonitorBrightnessEvent";
    
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
               Console.WriteLine("Listening {0}", "WmiMonitorBrightnessEvent");
               Console.WriteLine("Press Enter to exit");
               EventWatcherAsync eventWatcher = new EventWatcherAsync();
               Console.Read();
            }
        }
    }
