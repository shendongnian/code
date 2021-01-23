    class InternalSqm : IDisposable
    {
       private Boolean _disposed = false;
       //constructor
       public InternalSqm()
       {
          //...
          //Catch domain shutdown (Hack: frantically look for things we can catch)
          if (AppDomain.CurrentDomain.IsDefaultAppDomain())
             AppDomain.CurrentDomain.ProcessExit += MyTerminationHandler;
          else
             AppDomain.CurrentDomain.DomainUnload += MyTerminationHandler;
       }
       private void MyTerminationHandler(object sender, EventArgs e)
       {
          //The domain is dying. Serialize out our values
          this.Dispose();
       }
.
       /// <summary>
       /// Finalizer (Finalizer uses the C++ destructor syntax)
       /// </summary>
       ~InternalSqm()
       {
          Dispose(false); //False: it's not safe to access managed members
       }
       public void Dispose()
       {
          this.Dispose(true); //True; it is safe to access managed members
          GC.SuppressFinalize(this); //Garbage collector doesn't need to bother to call finalize later
       }
       protected virtual void Dispose(Boolean safeToAccessManagedResources)
       {
          if (_disposed)
             return; //be resilient to double calls to Dispose
          try
          {
             if (safeToAccessManagedResources)
             {
                // Free other state (managed objects).                   
                this.CloseSession(); //save internal stuff to persistent storage
             }
             // Free your own state (unmanaged objects).
             // Set large fields to null. Etc.
          }
          finally
          {
             _disposed = true;
          }
       }
    }
