    public Task DoIt()
    {
        // Returns a Task<bool>, but that's okay - it's still a Task
        return Task.FromResult(true);
    }
    public Task<bool> DoItAndReturnStuff()
    {
        return Task.FromResult(true);
    }
