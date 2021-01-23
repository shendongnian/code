    static void Main(string[] args)
    {
      using (ManagementEventWatcher eventWatcher =
                new ManagementEventWatcher(@"SELECT * FROM 
       __InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process'"))
      {
        // Subscribe for process creation notification.
        eventWatcher.EventArrived += ProcessStarted_EventArrived; 
        eventWatcher.Start();
        Console.In.ReadLine();
        eventWatcher.EventArrived -= ProcessStarted_EventArrived;
        eventWatcher.Stop();
      }
    }
    static void ProcessStarted_EventArrived(object sender, EventArrivedEventArgs e)
    {
      ManagementBaseObject obj = e.NewEvent["TargetInstance"] as ManagementBaseObject;
            
      // The Win32_Process class also contains a CreationDate property.
      Console.Out.WriteLine("ProcessName: {0} " + obj.Properties["Name"].Value);
    }
