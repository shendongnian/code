    // Window, application, etc - some longish-living object
    public class Something : IDisposable
    {
        CompositeDisposable _disposables = new CompositeDisposable();
        public Something()
        {
             // A composite disposable acts like a "bucket" of IDisposables
             // that are all disposed when the bucket is disposed.
              _disposables.Add(SomeObservable.Subscribe(...));
              _disposables.Add(SomeOtherObservable.Subscribe(...));
              _disposables.Add(YetAnotherObservable.Subscribe(...));
             // Here, optionally wire some "Yo, I should dispose when this happens" handler
             this.Closed += (o,e) => Dispose();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // clean up managed resources here
                if(_disposables != null)
                {
                    _disposables.Dispose();
                }
            }   
            // clean up unmanaged resources here
        }
        ~Something()
        {
            Dispose(false);
        }
    }
