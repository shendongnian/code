    ServiceController sc = new ServiceController("WebClient");
    if (sc.Status == ServiceControllerStatus.Stopped)
    {
        sc.Start();
        sc.WaitForStatus (ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
    }
