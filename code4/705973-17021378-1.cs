    using System.ServiceProcess;
    ServiceController sc = new ServiceController("My service name");
    if (sc.Status == ServiceControllerStatus.Stopped)
    {
       sc.Start();
    }
