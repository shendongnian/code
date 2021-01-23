    EventHandler SomeEvent;
    public void add_SomeEvent(EventHandler value){
        SomeEvent = (EventHandler)Delegate.Combine(SomeEvent, value);
    }
    public void remove_SomeEvent(EventHandler value){
        SomeEvent = (EventHandler)Delegate.Remove(SomeEvent, value);
    }
