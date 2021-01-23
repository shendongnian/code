    private static readonly object SomeEventKey = new object();
    public event EventHandler SomeEvent
    {
        add { Events.AddHandler(SomeEventKey, value); }
        remove { Events.RemoveHandler(SomeEventKey, value); }
    }
