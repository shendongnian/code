    public void Start()
    {
        _threads.Clear();
        _workers.Clear();
        for (int i = 0; i < _options.NumberOfClients; i++)
        {
            _workers.Add(new Worker());
            _threads.Add(new Thread(_workers.Last().PumpMessages));
            _threads.Last().Start();
        }
    }
