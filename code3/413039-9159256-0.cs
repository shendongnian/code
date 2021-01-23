    ServiceController sc = new ServiceController("Simple Service");
    if (sc.Status == ServiceControllerStatus.Stopped)
    {
        sc.Start();
        while (sc.Status == ServiceControllerStatus.Stopped)
        {
            Thread.Sleep(1000);
            sc.Refresh();
        }
    }
