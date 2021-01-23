        ServiceController sc = new ServiceController("World Wide Web Publishing Service");
    if ((sc.Status.Equals(ServiceControllerStatus.Stopped) || sc.Status.Equals(ServiceControllerStatus.StopPending))) {
        Console.WriteLine("Starting the service...");
        sc.Start();
    }
    else {
        Console.WriteLine("Stopping the service...");
        sc.Stop();
    }
