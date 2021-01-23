    using (ManagementEventWatcher eventWatcher =
              new ManagementEventWatcher(@"SELECT * FROM Win32_ProcessStartTrace"))
    {
      // Subscribe for process creation notification.
      eventWatcher.EventArrived += ProcessStarted_EventArrived;
      eventWatcher.Start();
      Console.Out.WriteLine("started");
      Console.In.ReadLine();
      eventWatcher.EventArrived -= ProcessStarted_EventArrived;
      eventWatcher.Stop();
    }
    static void ProcessStarted_EventArrived(object sender, EventArrivedEventArgs e)
    {               
      Console.Out.WriteLine("ProcessName: {0} " 
              + e.NewEvent.Properties["ProcessName"].Value);     
    }
