    using (ManagementEventWatcher eventWatcher =
           new ManagementEventWatcher(@"SELECT * FROM Win32_ProcessTrace"))
    {          
      eventWatcher.EventArrived += Process_EventArrived;
      eventWatcher.Start();
      Console.Out.WriteLine("started");
      Console.In.ReadLine();
      eventWatcher.EventArrived -= Process_EventArrived;
      eventWatcher.Stop();
    }
    static void Process_EventArrived(object sender, EventArrivedEventArgs e)
    {
      Console.Out.WriteLine(e.NewEvent.ClassPath); // Use class path to distinguish
                                                   // between start/stop process events.
      Console.Out.WriteLine("ProcessName: {0} " 
          + e.NewEvent.Properties["ProcessName"].Value);     
    }
