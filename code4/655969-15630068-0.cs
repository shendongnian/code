    public event CancelEventHandler Validating
    {
        add
        {
            base.Events.AddHandler(EventValidating, value);
        }
        remove
        {
            base.Events.RemoveHandler(EventValidating, value);
        }
    }
