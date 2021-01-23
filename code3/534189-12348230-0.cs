    [NonSerialized]
    private EventHandler foo;
    public event EventHandler {
        add { foo += value; }
        remove { foo -= value; }
    }
