    public async Task Run(string[] args)
    {
        if (SomethingHappened != null)
            await SomethingHappened.WhenInvokeAll(this, EventArgs.Empty);
    }
