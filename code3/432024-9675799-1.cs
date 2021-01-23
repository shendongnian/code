    private void OnEvent()
    {
        DoSomething();
    }
    private void DoSomething()
    {
        this.IsBusy = true;
        // do work
        // raise event
        if (!other.IsBusy)
            RaiseEvent();
    }
