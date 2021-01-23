    public static class LogConfigurator
    {
       public static void SetConnectionString(string connectionString)
       {
            Hierarchy logHierarchy = log4net.LogManager.GetRepository() as Hierarchy;
    
            if (logHierarchy == null)
            {
                throw new InvalidOperationException
                   ("Can't set connection string as hierarchy is null.");
            }
    
            var appender = logHierarchy.GetAppenders()
                                       .OfType<AdoNetAppender>()
                                       .SingleOrDefault();
    
            if (appender == null)
            {
                throw new InvalidOperationException
                  ("Can't locate a database appender");
            }
    
            appender.ConnectionString = connectionString;
            appender.ActivateOptions();
       }
    }
