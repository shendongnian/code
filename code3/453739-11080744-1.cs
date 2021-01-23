    using System;
    using log4net;
    using log4net.Config;
    
    
    public class MyApp
    {
        // Define a static logger variable so that it references the
        // Logger instance named "MyApp".
        private static readonly ILog log = LogManager.GetLogger(typeof(MyApp));
        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo(@"..\..\resources\log4net.config"));
            log.Info("Entering application.");
            Console.WriteLine("starting.........");
            log.Info("Entering application.");
            log.Error("Exiting application.");
            Console.WriteLine("starting.........");
        }
    }
