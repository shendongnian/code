    public class HasUnmanaged : IDisposable
    {
      IDisposable managedGoo;
      public void Dispose()
      {
        if(managedGoo != null)
          managedGoo.Dispose();
      }
    }
