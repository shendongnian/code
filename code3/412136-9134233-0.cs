    public event EventHandler Event0;
    public event EventHandler Event1;
    public event EventHandler Event2;
    public List<EventHandler> Events;
    public void AddEvents( )
    {
        Events = new List<EventHandler> { Event0, Event1, Event2 };
        Event0 += new EventHandler(EventHandler0);
        Events[1] += new EventHandler(EventHandler1);
    }
