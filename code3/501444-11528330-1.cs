    // This is the entry point
    static void Main(string[] args)
    {
        // If parameter passed, act on it
        if ( args.Length > 0 )
        {
            switch (args[0] )
            {
                // Debug the service as a normal app from within Visual Studio
                case DEBUG:
                    MyService DebugService = new MyService();
                    DebugService.OnStart(null);
                    break;
                // Install the service programatically
                case INSTALL:
                    ManagedInstallerClass.InstallHelper(new string[] _
                    { Assembly.GetExecutingAssembly().Location });
                    break;
                // Un-install the service programatically
                case UNINSTALL:
                    ManagedInstallerClass.InstallHelper(new string[] +
                    { UNINSTALL, Assembly.GetExecutingAssembly().Location });
                    break;
                // We don't understand this parameter!
                default:
                    message = string.Concat(DEBUG, " to run service manually.", Environment.NewLine);
                    message += string.Concat(INSTALL, " to install service.", Environment.NewLine);
                    message += string.Concat(UNINSTALL, " to un-install service.", Environment.NewLine);
                    message += string.Concat("Do not understand the command-line parameter ", args[0]);
                    throw new System.NotImplementedException(message);
            }
        }
        // If no parameter passed, just start the service normally
        else
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new MyService() };
            ServiceBase.Run(ServicesToRun);
        }
    }
