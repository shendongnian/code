    public void processEvents()
    {
        // edit: derp, 'event' is a keyword, so I'm
        // renaming this, since I won't get into why
        // you could also use @event...
        foreach(var evt in eventList)
        {
            evt.Execute();
        }
    }
