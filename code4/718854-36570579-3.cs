    public bool IsInitialized
    {
        get
        {
            Contract.Ensures(Contract.Result<bool>() ^ !_initialized);
            return _initialized; 
        }
    }
