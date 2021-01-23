    class SomeWorkflowControlObject : IDisposable
    {
         // the following event doesn't make sense, sorry.
         // public event EventHandler<> ObjectTerminated;
    
         private IntPtr _handleToUnmanagedResource;
         ~SomeWorkflowControlObject()
         {
             Dispose(explicitly: false);         
         }
         public void Dispose()
         {
             Dispose(explicitly: true);
             GC.SuppressFinalize(this);
         }
         protected virtual void Dispose(bool explicitly)
         {
             if (explicitly)
             {
                 // free managed resources here; perhaps trigger an event 'Disposing'.
             }
             DisposeUnmanagedResource(_handleToUnmanagedResource);
         }
    }
