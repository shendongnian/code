    public async Task Run(string[] args)
    {
        if (SomethingHappened != null)
            await SomethingHappened.InvokeAllAsync(this, EventArgs.Empty);
    }
