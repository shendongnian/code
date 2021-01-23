        static void Main(string[] args)
        {
            ServiceTemplate service = new ServiceTemplate();
            if (Environment.UserInteractive)
            {
                // The application is running from a console window, perhaps creating by Visual Studio.
                try
                {
                    if (Console.WindowHeight < 10)
                        Console.WindowHeight = 10;
                    if (Console.WindowWidth < 240) // Maximum supported width.
                        Console.WindowWidth = 240;
                }
                catch (Exception)
                {
                    // We couldn't resize the console window.  So it goes.
                }
                service.OnStart(args);
                Console.Write("Press any key to stop program: ");
                Console.ReadKey();
                Console.Write("\r\nInvoking OnStop() ...");
                service.OnStop();
                Console.Write("Press any key to exit: ");
                Console.ReadKey();
            }
            else
            {
                // The application is running as a service.
                // Misnomer.  The following registers the services with the Service Control Manager (SCM).  It doesn't run anything.
                ServiceBase.Run(service);
            }
        }
