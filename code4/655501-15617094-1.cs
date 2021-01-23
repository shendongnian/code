    private EventHandler onMyEvent;
    public event MyEventHandler MyEvent
    {
        add
        {
            // run when event handler is added ( += )
            onMyEvent = (MyEventHandler)Delegate.Combine(onMyEvent, value);
            // Add additional, custom logic here...
        }
 
        remove
        {
            // run when event handler is removed ( -= )
            onMyEvent = (MyEventHandler)Delegate.Remove(onMyEvent, value);
        }
    }
