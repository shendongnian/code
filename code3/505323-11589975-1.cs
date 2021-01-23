    public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool b)
        {
            if (b)
            {
                if (cat!=null) {
                    var disposableCat = cat as IDisposable;
                    if (disposableCat != null) {
                       disposableCat.Dispose();
                       cat=null;
                    }
                }
            }
        }
