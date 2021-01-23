    private EventHandler<EventArgs> myEvent;
    
    public event EventHandler<EventArgs> MyEvent
    {
        add
        {
            myEvent = (EventHandler<EventArgs>)Delegate.Combine(myEvent, value);
        }
        remove
        {
            myEvent = (EventHandler<EventArgs>)Delegate.Remove(myEvent, value);
        }
    }
