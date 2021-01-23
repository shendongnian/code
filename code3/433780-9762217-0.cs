    public class MyClass
    {
      private static readonly Logger logger = LogManager.GetCurrentClassLogger();
      public void DoSomething()
      {
        logger.Debug("Hello from inside DoSomething");
      }
    }
