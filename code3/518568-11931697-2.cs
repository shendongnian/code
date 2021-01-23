    [assembly: log4net.Config.XmlConfigurator(Watch = true)]
    [assembly: log4net.Config.Repository()]
    namespace MyApp
    {
        public class Main
        {
           private static readonly ILog log = LogManager.GetLogger(typeof(Main));
        }
    }
