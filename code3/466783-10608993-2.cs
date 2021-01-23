    public void DoCallback() 
    {
        Action local = Interlocked.CompareExchange(ref _Callback, null, null);
        if (local != null)
            local();
    }
