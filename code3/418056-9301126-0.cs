    public class Example
    {
      private bool b = false;
      public void DoSomething()
      {
        if (!b)
        {
          b = true;
          DoExtraStuff();
        }
      }
    }
