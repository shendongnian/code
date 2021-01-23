    using Com.Foo;
    
    // Import log4net classes.
    using log4net;
    using log4net.Config;
    
    public class MyApp 
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MyApp));
    
        static void Main(string[] args) 
        {
            // BasicConfigurator replaced with XmlConfigurator.
            XmlConfigurator.Configure(new System.IO.FileInfo(args[0]));
    
            log.Info("Entering application.");
            Bar bar = new Bar();
            bar.DoIt();
            log.Info("Exiting application.");
        }
    }
