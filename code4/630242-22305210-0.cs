    public class Global : HttpApplication
    {
       public const String WurflDataFilePath = "~/App_Data/wurfl.zip";
       private void Application_Start(Object sender, EventArgs e)
       {
           var wurflDataFile = HttpContext.Current.Server.MapPath(WurflDataFilePath);
           var configurer = new InMemoryConfigurer().MainFile(wurflDataFile);
           var manager = WURFLManagerBuilder.Build(configurer);
           HttpContext.Current.Cache[WurflManagerCacheKey] = manager;
       }
    }  
