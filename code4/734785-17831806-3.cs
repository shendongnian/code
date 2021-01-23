    public static void StartService(string serviceName, int timeoutMilliseconds)
    {
      ServiceController service = new ServiceController(serviceName);
      try
      {
        TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
    
        service.Start();
        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
      }
      catch
      {
        // ...
      }
    }
