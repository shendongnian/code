    // NativeWrapper is a managed resource
    class NativeWrapper : IDispoable
    {
      // _handle is a native resource
      private readonly IntPtr _handle;
      
      public NativeWrapper()
      {
        _handle = ObtainResourceFromNativeWorld();
      }
      
      public void Dispose()
      {
        Dispose(true);
      }
    
      ~NativeWraper()
      {
        Dispose(false);
      }
    
      private void Dispose(bool disposing)
      {
        // because we're dealing with native resources
        // we should release them from both: Dispose method and Finalizer
        ReleaseResourceToNativeWorld(_handle);
      }
    }
