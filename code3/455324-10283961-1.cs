    class SomethingToDispose : IDisposable
    {
      private SomethingDisposable resource = new SomethingDisposable();
    
      public void someMethod()
      {
        //code that uses resource 
      }
    
      //code to dispose of resource in a Dispose method.
    }
