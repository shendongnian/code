    class MyClass
    {
    private static readonly _myEvent = new object();
    private EventHandlerList _handlers = new EventHandlerList();
    public event EventHandler MyEvent
    {
        add 
        { 
           _handlers.AddHandler(_myEvent, value); 
           OnMyEvent(); // fire the startup event
        }
        remove { _handlers.RemoveHandler(_myEvent, value); }
    }
    private void OnMyEvent()
    {
        EventHandler myEvent = _handlers[_myEvent] as EventHandler;
        if (myEvent != null) myEvent(this, EventArgs.Empty);
    }
    ...
    }
