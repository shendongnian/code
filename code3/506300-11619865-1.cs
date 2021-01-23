    public ExceptionEventArgs : EventArgs
    {
        public bool HasErrors { get; private set; }
        // Anything you else you want, like a list of error strings etc...
    }
    
    void HandleError(object sender, ExceptionEventArgs e)
    {
        e.HasErrors = true;
        // ... your logic here
    }
    
    void Validate()
    {
        var eventArgs = new ExceptionEventArgs()
        OnHandleError(this, eventArgs);
        if(eventArgs.HasErrors)
            // do something special
    }
