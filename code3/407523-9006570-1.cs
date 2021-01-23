        private static void Main()
        {            
            #if !DEBUG
            var servicesToRun = new [] { new DemoService() };
            Debug.WriteLine("Run service...");
            Run(servicesToRun);      
            #else
            DemoService service = new DemoService();
            service.OnStart(null);
            Console.WriteLine("Press ENTER to quit...");
            Console.ReadLine();
            
            service.OnStop();
            #endif
        }
