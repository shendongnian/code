    //You should select Console Application from Application properties
    static void Main(string[] args)
        {
            MyWindowsService service = new MyWindowsService();
            if (Environment.UserInteractive)
            {
                service.OnStart(args);
                Console.WriteLine("Press any key to stop program");
                Console.Read();
                service.OnStop();
            }
            else
            {
                ServiceBase.Run(service);
            }
        } 
