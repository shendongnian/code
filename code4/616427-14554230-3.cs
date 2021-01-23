    public sealed class SomeDisposable:IDisposable
    {
        public void Dispose()
        {
           //just go ahead and clean up
           //because we're sealed, no-one can ever break
           //this code via inheritance
        }
        //~SomeDisposable()
        //{
        //   if this is being called then it will be called
        //   on all referenced and unrooted IDisposables too
        //   If everything is managed, that means we've got nothing
        //   left to clean up, so we can omit this Finalizer 
        //}
    }
    
