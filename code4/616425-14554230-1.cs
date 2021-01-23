    public sealed class SomeDisposable:IDisposable
    {
        public void Dispose()
        {
           //just go ahead and clean up
           //because we're sealed, no-one can ever break
           //this code via inheritance
        }
    }
    
