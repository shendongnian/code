    public abstract class AMyClass
    {
      protected ITimer MyTimer;
    
      public AMyClass(ITimer timer)
      {
        MyTimer = timer;
      }
    
      public abstract void DoSomething();
    }
    
    public class MyClass : AMyClass
    {
      public override void DoSomething()
      {
    
      }
    }
