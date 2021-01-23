    public class Example
    {
      private int b = 0;
      public void DoSomething()
      {
        if (Interlocked.CompareExchange(ref b, 0, 1) == 0)
        {
          DoExtraStuff();
        }
      }
    }
