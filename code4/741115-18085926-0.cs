    // using System.Management;
    // reference System.Management.dll
    void Main()
    {    
        using(var control = new USBControl()){
            Console.ReadLine();//block - depends on usage in a Windows (NT) Service, WinForms/Console/Xaml-App, library
        }
    }
    
    class USBControl : IDisposable
        {
            // used for monitoring plugging and unplugging of USB devices.
            private ManagementEventWatcher watcherAttach;
            private ManagementEventWatcher watcherDetach;
    
            public USBControl()
            {
                // Add USB plugged event watching
                watcherAttach = new ManagementEventWatcher();
                //var queryAttach = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
                watcherAttach.EventArrived += Attaching;
                watcherAttach.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
                watcherAttach.Start();
    
                // Add USB unplugged event watching
                watcherDetach = new ManagementEventWatcher();
                //var queryRemove = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
                watcherDetach.EventArrived += Detaching;
                watcherDetach.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
                watcherDetach.Start();
            }
            
            public void Dispose()
            {
                watcherAttach.Stop();
                watcherDetach.Stop();
                //you may want to yield or Thread.Sleep
                watcherAttach.Dispose();
                watcherDetach.Dispose();
                //you may want to yield or Thread.Sleep
            }
    
            void Attaching(object sender, EventArrivedEventArgs e)
            {
                if(sender!=watcherAttach)return;
                e.Dump("Attaching");
            }
    
            void Detaching(object sender, EventArrivedEventArgs e)
            {
                if(sender!=watcherDetach)return;
                e.Dump("Detaching");
            }
    
            ~USBControl()
            {
                this.Dispose();
            }
        }
