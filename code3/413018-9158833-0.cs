    private SomeEventHandler _someEvent;
    public event SomeEventHandler SomeEvent
    {
        add
        {
            _someEvent += value;
            Console.WriteLine("Someone subscribed to SomeEvent");
        }
        remove
        {
            _someEvent -= value;
            Console.WriteLine("Someone unsubscribed from SomeEvent");
        }
    }
