    private static CometService instance = null;
    
    protected override void OnStart(...)
    {
        instance = this;
        ...
    }
    
    protected override void OnStop()
    {
        object.ReferenceEquals(this, instance);
        ...
    }
