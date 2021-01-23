    public class Subclass : BaseClass
    {
      public void Something()
      {
        using (var complete = new ManualResetEventSlim(false))
        {
          EventHandler handler = (sender, args) => { complete.Set(); };
          base.OnBeginSomethingCompleted += handler;
          try
          {
            base.BeginSomething();
            complete.Wait();
          }
          finally
          {
            base.OnBeginSomethingCompleted -= handler;
          }
        }
      }
    }
