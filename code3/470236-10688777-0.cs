    public partial class DemoService : ServiceBase
    {
        static void Main(string[] args)
        {
            DemoService service = new DemoService();
     
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
