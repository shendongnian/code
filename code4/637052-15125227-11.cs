    private Type FindPresenterDescribedViewTypeCached(Type presenter, 
        IView view) 
    {
        IntPtr handle = presenter.TypeHandle.Value;
        if (!this.cache.ContainsKey(handle)) 
        {
            lock (this.syncLock)
            {
                if (!this.cache.ContainsKey(handle))
                {
                    Type viewType = CreateType(presenter, view);
                    this.cache[handle] = viewType;
                    return viewType;
                }
            }
        }
        return this.cache[handle];
    }
