    private EventRegistrationTokenTable<EventHandler<Object>> _changed
         = new EventRegistrationTokenTable<EventHandler<Object>>();
    public event EventHandler<Object> Changed
    {
        add    { return _changed.AddEventHandler(value); }
        remove { _changed.RemoveEventHandler(value);     }
    }
