    // Interface which plugins must implement
    public interface IPlugin
    {
      void DoSomething(int Data);
    }
    
    // Custom plugin which implements interface
    public class Plugin : IPlugin
    {
      public void DoSomething(int Data)
      {
        // Do something
      }
    }
