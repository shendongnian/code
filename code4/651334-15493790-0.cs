    static class Program
    {
        static void Main(params string[] args)
        {
            var service = new Service1();
    
            if (!Environment.UserInteractive)
            {
                var servicesToRun = new ServiceBase[] { service };
                ServiceBase.Run(servicesToRun);
                return;
            }
    
            Console.WriteLine("Running as a Console Application");
            Console.WriteLine(" 1. Run Service");
            Console.WriteLine(" 2. Other Option");
            Console.WriteLine(" 3. Exit");
            Console.Write("Enter Option: ");
    
            var input = Console.ReadLine();
    
            switch (input)
            {
                case "1":
                    service.Start(args);
                    Console.WriteLine("Running Service - Press Enter To Exit");
                    Console.ReadLine();
                    break;
                case "2":
                    break;
            }
            Console.WriteLine("Closing");
        }
    }
    
    public partial class Service1 : ServiceBase
    {
        public Service1() { InitializeComponent(); }
        public void Start(string[] args) { OnStart(args); }
        protected override void OnStart(string[] args) { }
        protected override void OnStop() { }
    }
