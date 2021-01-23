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
                //in this point the new events arrives
                //you can access to any property of the Win32_Process class
                Console.WriteLine("TargetInstance.Handle :    " + ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["Handle"]);
                Console.WriteLine("TargetInstance.Name :      " + ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["Name"]);
      
            }
    
            public EventWatcherAsync()
            {
                try
                {
                    string ComputerName = "localhost";
                    string WmiQuery;
                    ManagementEventWatcher Watcher;
                    ManagementScope Scope;                
    
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
                    Scope.Connect();
    
                    WmiQuery ="Select * From __InstanceCreationEvent Within 1 "+
                    "Where TargetInstance ISA 'Win32_Process' ";
    
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
               Console.WriteLine("Listening process creation, Press Enter to exit");
               EventWatcherAsync eventWatcher = new EventWatcherAsync();
               Console.Read();
            }
        }
    }
