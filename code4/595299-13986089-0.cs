    private EventHandler someEvent;
    public event EventHandler SomeEvent
    {
        add { someEvent += value; }
        remove { someEvent -= value; }
    }
