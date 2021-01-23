    public event AsyncEventHandler<EventArgs> SomethingHappened;
    
    public void SubscribeToMyOwnEventsForNoReason()
    {
        SomethingHappened += async (sender, e) =>
        {
            SomethingSynchronous();
            await SomethingAsynchronousAsync();
            SomeContinuation();
        };
    }
