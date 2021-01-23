    public class MyClass : IDisposable
    {
      ~MyClass (){ Dispose(false); /*destructor*/ }
      
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
      private void Dispose(bool disposing)
      {
        if(disposing)
        {
           //handle your dispose here
        }
      }
    }
