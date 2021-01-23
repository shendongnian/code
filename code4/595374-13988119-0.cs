        /// <summary>
        ///   The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            var myService = new MyService();
            if (Environment.UserInteractive)
            {
                Console.WriteLine("Starting service...");
                myService.Start();
                Console.WriteLine("Service is running.");
                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);
                Console.WriteLine("Stopping service...");
                myService.Stop();
                Console.WriteLine("Service stopped.");
            }
            else
            {
                var servicesToRun = new ServiceBase[] { myService };
                ServiceBase.Run(servicesToRun);
            }
        }
