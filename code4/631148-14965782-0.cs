    public Task MyMethod()
    {
        return MethodIDontOwnThatReturnsTask()
            .ContinueWith(t => { throw Tweak(t.Exception); }
            , TaskContinuationOptions.OnlyOnFaulted);
    }
