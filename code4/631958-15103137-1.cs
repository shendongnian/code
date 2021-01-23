    object gate = new object();
    ManualResetEvent mre = new ManualResetEvent(false /*initialState*/);
    ConcurrentDictionary<Guid, int> _bBag = new ConcurrentDictionary<Guid, int>();
    public Message WrapA(int a, int millisecondsTimeout)
    {
        Message message = null;
        int? b = null;
        lock (gate)
        {
            if (!_bBag.IsEmpty)
            {
                Guid key = _bBag.Keys.FirstOrDefault();
                int gotB = 0;
                if (_bBag.TryRemove(key, out gotB))
                {
                    b = gotB;
                    Monitor.PulseAll(gate);
                }
            }
        }
        message = new Message(a, b);
        return message;
    }
    public Message WrapB(int b, int millisecondsTimeout)
    {
        Guid key = Guid.NewGuid();
        _bBag.TryAdd(key, b);
        mre.WaitOne(millisecondsTimeout);    // use a manual reset instead of Monitor
        int storedB = 0;
        if (_bBag.TryRemove(key, out storedB))
        {
            return new Message(null, b);
        }
        return null;
    }
