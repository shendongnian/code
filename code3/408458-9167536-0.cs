    public class MyWindowsService : ServiceBase
    {
        public static void Main(string[] args)
        {
            // if configuration says to run in the console, run the service in a console app. otherwise, use windows
            // service to host application
            if (ConfigurationManager.AppSettings["RunInConsole"] == "true")
            {
                using (ServiceHost host = new ServiceHost(typeof(MyService)))
                {
                    host.Open();
                    Console.WriteLine("Press <Enter> to terminate the Host application.");
                    Console.ReadLine();
                }
            }
            else
                ServiceBase.Run(new MyWindowsService ());
        }
    }
