    static void Main(string[] args)
    {
        if (Environment.UserInteractive)
        {
            string parameter = string.Concat(args);
            switch (parameter)
            {
                case "--install":
                ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });
                break;
                case "--uninstall":
                ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
                break;
            }
        }
        else
        {
            ServiceBase[] servicesToRun = new ServiceBase[] 
                              { 
                                  new Service1() 
                              };
            ServiceBase.Run(servicesToRun);
        }
    }
