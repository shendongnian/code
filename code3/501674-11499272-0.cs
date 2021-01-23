     var Service = new ServiceController(servicetowach);
                        if (Service.Status != ServiceControllerStatus.Running
                            && Service.Status != ServiceControllerStatus.StartPending)
                        {
    Service.Start();
    }
