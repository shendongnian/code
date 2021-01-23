    class MyComponent
    {
      void DoSomeWork()
      {
        // Get an instance of the logger
        ILogger logger = Helpers.GetLogger();
        // Get data to log
        string data = GetData();
    
        // Log
        logger.Log(data);
      }
    }
    
    class Helpers
    {
      public static ILogger GetLogger()
      {
        // Here, use any sophisticated logic you like
        // to determine the right logger to instantiate.
    
        ILogger logger = null;
        if (UseDatabaseLogger)
        {
            logger = new DatabaseLogger();
        }
        else
        {
            logger = new FileLogger();
        }
        return logger;
      }
    }
    class FileLogger : ILogger
    {
        .
        .
        .
    }
    
    class DatabaseLogger : ILogger
    {
        .
        .
        .
    }
