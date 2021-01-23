    static void Main()
    {
        try
        {
    #if DEBUG
            // Run as interactive exe in debug mode to allow easy debugging. 
            var service = new Service1();
            service.OnDebugMode_Start();
            // Sleep the main thread indefinitely while the service code runs in OnStart() 
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            service.OnDebugMode_Stop();
    #else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
                               { 
                                         new Service1() 
                               };
            ServiceBase.Run(ServicesToRun);
    #endif
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
