    public class Example
    {
      private bool b = false;
      private object locker = new object();
      public void DoSomething()
      {
        bool trigger = false;
        lock (locker)
        {
          if (!b)
          {
            b = true;
            trigger = true;
          }
        }
        if (trigger)
        {
          DoExtraStuff();
        }
      }
    }
