    private readonly List<LoggingEvent> _loggingEvents = new List<LoggingEvent>();
    
     private static ILog log;
            public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().GetType());
    
            static void init_log()
            {
                GlobalContext.Properties["addr"] = System.Web.HttpContext.Current.Request.UserHostAddress;
                GlobalContext.Properties["browser"] = System.Web.HttpContext.Current.Request.Browser.Browser + " : " + System.Web.HttpContext.Current.Request.Browser.Version;
                GlobalContext.Properties["url"] = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
    
                log4net.Config.XmlConfigurator.Configure();
    
            }
    
     LoggingEvent[] bufferedEvents = _loggingEvents.ToArray();
    
    foreach (var loggingEvent in events)
                {
                    if (loggingEvent.Level == Level.Warn || loggingEvent.Level == Level.Info || loggingEvent.Level == Level.Debug || loggingEvent.Level == Level.All)
                    {
                         log.Info(message);
                         
                   }
    
                }
