    public event EventHandler SomethingHappened;
    private void OnSomethingHappened()
    {
        var handler = SomethingHappened;
        if (handler != null)
            handler(this, EventArgs.Empty);
    }
