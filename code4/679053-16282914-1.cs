    using System.ServiceProcess;
    ...
    using (var controller = new ServiceController("myservicename")) {
        controller.Stop();
        controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(15.0));
    }
