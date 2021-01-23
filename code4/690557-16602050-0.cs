    class Test : IDisposable
       {
         private bool isDisposed = false;
    
         ~Test()
         {
           Dispose(false);
         }
    
         protected void Dispose(bool disposing)
         {
           if (disposing)
           {
             // Code to dispose the managed resources of the class
             internalComponent1.Dispose();
             internalComponent2.Dispose();
           }
           // Code to dispose the un-managed resources of the class
           CloseHandle(handle);
           handle = IntPtr.Zero;   
    
           isDisposed = true;
         }
    
         public void Dispose()
         {
           Dispose(true);
           GC.SuppressFinalize(this);
         }
       }
