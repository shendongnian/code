    [NonSerialized]
    private ChangedEventHandler _changed;
    public event ChangedEventHandler Changed
    {
        add { _changed += value; }
        remove { _changed -= value; }
    }
