    private EventHandler SomeEvent;
    
    public event EventHandler
    {
        add
        {
            SomeEvent += value;
        }
        remove
        {
            SomeEvent -= value;
        }
    }
