    public event Action OnDisposing;
    
    protected override void Dispose(bool disposing)
    {
    	if (OnDisposing != null) OnDisposing.Invoke();
    	base.Dispose();
    }
