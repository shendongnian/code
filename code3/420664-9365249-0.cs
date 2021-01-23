    public class MyConsumer
    {
      private readonly Func<MyService> factory;
      public MyConsumer(Func<MySerivce> factory)
      {
        this.factory = factory;
      }
      public void NeedsMyServiceOnEveryCall(...)
      {
        var svc = factory();
        svc.Method();
      }
    }
