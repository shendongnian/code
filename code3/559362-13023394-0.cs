    private Action _myEvent;
    public event Action MyEvent
    {
        add
        {
            Console.WriteLine("Listener added!");
            _myEvent += value;
        }
        remove
        {
            Console.WriteLine("Listener removed!");
            _myEvent -= value;
        }
    }
