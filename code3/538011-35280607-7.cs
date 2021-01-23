    public event AsyncEventHandler<EventArgs> SomethingHappened;
    
    public void SubscribeToMyOwnEventsForNoReason()
    {
        SomethingHappened += async (sender, e) =>
        {
            SomethingSynchronous();
            // Safe to touch e here.
            await SomethingAsynchronousAsync();
            // No longer safe to touch e here (please understand
            // SynchronizationContext well before trying fancy things).
            SomeContinuation();
        };
    }
