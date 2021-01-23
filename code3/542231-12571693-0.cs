    public ShellViewModel(IEventAggregator events)
    {
        // Subscribe to MessageDisplayed events
        events.GetEvent<MessageDisplayedEvent>().Subscribe(HandleMessageDisplayed);
    }
    
    void HandleMessageDisplayed(MessageDisplayedEvent e)
    {
        if (e.SomeBooleanProperty)
            // Do Work
    }
