    public void Start()
    {
        _threads.Clear();
        _workers.Clear();
        var evts = new List<ManualResetEvent>()
        for (int i = 0; i < _options.NumberOfClients; i++)
        {
            ManualResetEvent evt = new ManualResetEvent(false);
            evts.Add(evt);
            _workers.Add(new Worker(evt));
            _threads.Add(new Thread(_workers.Last().PumpMessages));
            _threads.Last().Start();
        }
        WaitHandle.WaitAll(evts.ToArray());
    }
