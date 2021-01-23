    public class MyClass
    {
      private static readonly Logger logger = LogManager.GetCurrentClassLogger();
      public void SomeMethod(int x, int y)
      {
        using (new EnterExitLogger(logger, "SomeMethod", x, y))
        {
          //Do your work here
        }
      }
    }
