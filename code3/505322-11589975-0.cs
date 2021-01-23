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
                    cat.Dispose();
                    cat=null;
                }
            }
        }
