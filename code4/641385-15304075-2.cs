    public class MyClassWhereIWantToUseLogging
    {
      private static readonly _logger = new MyLogger(LogManager.GetCurrentClassLogger());
      public void DoSomething()
      {
        _logger.Info("Hello!"); //If you log call site info, you should class name and method name.
      }
    }
