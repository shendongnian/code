    public static int Main(string[] args)
    {
        if (System.Environment.UserInteractive)
        {
            // we only care about the first two characters
            string arg = args[0].ToLowerInvariant().Substring(0, 2);
    
            switch (arg)
            {
                case "/i":  // install
                    return InstallService();
    
                case "/u":  // uninstall
                    return UninstallService();
    
                default:  // unknown option
                    Console.WriteLine("Argument not recognized: {0}", args[0]);
                    Console.WriteLine(string.Empty);
                    DisplayUsage();
                    return 1;
            }
        }
        else
        {
            // run as a standard service as we weren't started by a user
            ServiceBase.Run(new CSMessageQueueService());
        }
    
        return 0;
    }
    
    private static int InstallService()
    {
        var service = new MyService();
    
        try
        {
            // perform specific install steps for our queue service.
            service.InstallService();
    
            // install the service with the Windows Service Control Manager (SCM)
            ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null && ex.InnerException.GetType() == typeof(Win32Exception))
            {
                Win32Exception wex = (Win32Exception)ex.InnerException;
                Console.WriteLine("Error(0x{0:X}): Service already installed!", wex.ErrorCode);
                return wex.ErrorCode;
            }
            else
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
    
        return 0;
    }
    
    private static int UninstallService()
    {
        var service = new MyQueueService();
    
        try
        {
            // perform specific uninstall steps for our queue service
            service.UninstallService();
    
            // uninstall the service from the Windows Service Control Manager (SCM)
            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
        }
        catch (Exception ex)
        {
            if (ex.InnerException.GetType() == typeof(Win32Exception))
            {
                Win32Exception wex = (Win32Exception)ex.InnerException;
                Console.WriteLine("Error(0x{0:X}): Service not installed!", wex.ErrorCode);
                return wex.ErrorCode;
            }
            else
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
    
        return 0;
    }
