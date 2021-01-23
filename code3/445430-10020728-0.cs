    [DllImport("kernel32")]
    static extern bool AllocConsole();
    
    private static void Main(string[] args)
    {
        var service = new MyService();
        var controller = ServiceController.GetServices().FirstOrDefault(c => c.ServiceName == service.ServiceName);
        if (null != controller && controller.Status == ServiceControllerStatus.StartPending)
        {
            ServiceBase.Run(service);
        }
        else
        {
            if (AllocConsole())
            {
                service.OnStart(args);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                service.OnStop();
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }
