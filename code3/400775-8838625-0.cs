    public class HasUnmanaged : IDisposable
    {
      IntPtr unmanagedGoo;
      private void CleanUp()
      {
        if(unmanagedGoo != IntPtr.Zero)
        {
          SomeReleasingMethod(unmanagedGoo);
          unmanagedGoo = IntPtr.Zero;
        }
      }
      public void Dispose()
      {
        CleanUp();
        GC.SuppressFinalize(this);
      }
      ~HasUnmanaged()
      {
        CleanUp();
      }
    }
