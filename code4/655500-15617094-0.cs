    private EventHandler onMyEvent;
    public event MyEventHandler MyEvent
    {
        add
        {
            // run when event handler is added ( += )
            onMyEvent = (MyEventHandler)Delegate.Combine(onMyEvent, value);
        }
 
        remove
        {
            // run when event handler is removed ( -= )
            onMyEvent = (MyEventHandler)Delegate.Remove(onMyEvent, value);
        }
    }
