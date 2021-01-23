    object gate = new object();
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
        lock (gate) { Monitor.Wait(gate, millisecondsTimeout); }
        int storedB = 0;
        if (_bBag.TryRemove(key, out storedB))
        {
            return new Message(null, b);
        }
        return null;    
    }
