     if (Environment.UserInteractive)
     {
                bool install = false;
                bool uninstall = false;
                string serviceName = "YourDefaultServiceName";
                var p = new OptionSet()
                  .Add<bool>("i|install", "Install Windows Service", i => install = i)
                  .Add<bool>("i|install=", "Install Windows Service", i => install = i)
                  .Add<bool>("u|uninstall", "Uninstall Window Service", u => uninstall = u)
                  .Add<string>("sn|service_name=", "Service Name", n => serviceName = n);
                p.Parse(args);
                if (install)
                {
                    BasicServiceInstaller.Install(serviceName);
                    return;
                }
                else if (uninstall)
                {
                    BasicServiceInstaller.Uninstall(serviceName);
                    return;
                }
                // if no install or uninstall commands so start the service as a console.
                var host = new YourService();
                host.Start(args);
                Console.ReadKey();
            }
            else
            {
                ServiceBase.Run(new HotspotCenterService());
       }
