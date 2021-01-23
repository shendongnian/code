    public event EventHandler SomeEvent;
    protected virtual void OnSomeEvent()
    {
        var snapshot = SomeEvent;
        if (snapshot != null) snapshot(this, EventArgs.Empty);
    }
