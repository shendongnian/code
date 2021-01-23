    class MyResource : IDisposable { 
      public MyResource() {
        // Acquire resource here
      }
    
      public void Dispose() {
        // Free resource here, along with extra stuff to attempt
        // to catch situations where its not disposed 
      }
    }
