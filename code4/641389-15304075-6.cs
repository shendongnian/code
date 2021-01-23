    public class MyClassFromWhichIWantToLog
    {
      private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
      public void DoSomething()
      {
        _logger.Info("Hello!");
      }
    }
