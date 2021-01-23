    public sealed class HandlesUnmanaged : IDisposable
    {
      private IntPtr _someUnmanagedHandleOfSomeKind;
      public string DoSomething(string someParam)
      {
        // your useful code goes here;
        // make it thin, non-virtual and likely to be inlined
        // if you need to extend functionality, but it in a
        // containing Disposable class, not a derived class.
      }
      private void CleanUp()
      {
        //your code that cleans-up someUnmanagedHandleOfSomeKind goes here
      }
      public void Dispose()
      {
        CleanUp();
        GC.SuppressFinalize(this);//finaliser not needed now.
      }
      ~HandlesUnmanaged()//not called if already disposed
      {
        CleanUp();
      }
    }
