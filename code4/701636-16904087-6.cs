    static partial class Program
    {
        static void Main(string[] args)
        {
            RunAsService();
        }
    
        static void RunAsService()
        {
            ServiceBase[] servicesToRun;
            servicesToRun = new ServiceBase[] { new MainService() };
            ServiceBase.Run(servicesToRun);
        }
    }
