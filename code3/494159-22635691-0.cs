    static class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Any(arg => arg == "/i" || arg == "/u"))
            {
                // Install or Uninstall the service (mimic InstallUtil.exe)
                System.Configuration.Install.ManagedInstallerClass.InstallHelper(args);
            }
            else
            {
                // Run the service
                System.ServiceProcess.ServiceBase[] ServicesToRun;
                ServicesToRun = new System.ServiceProcess.ServiceBase[] 
    		    { 
    			    new MyService() 
    		    };
                System.ServiceProcess.ServiceBase.Run(ServicesToRun);
            }
        }
    }
