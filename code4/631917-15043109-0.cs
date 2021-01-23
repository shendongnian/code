    object gate = new object();
    int? pendingA;
    public Message WrapA(int a, int millisecondsTimeout)
    {
        bool queued = false;
        lock (gate)
        {
            if (pendingA == null)
            {
                queued = true;
                pendingA = a;
                Monitor.Pulse(gate);
            }
        }
        if (queued)
        {
            Thread.Sleep(3);
            lock (gate)
            {
                if (pendingA == null)
                    return null;
                a = pendingA.Value;
                pendingA = null;
            }
        }
        return new Message(a, null);
    }
    public Message WrapB(int b, int millisecondsTimeout)
    {
        int? a;
        lock (gate)
        {
            if (pendingA == null)
                Monitor.Wait(gate, millisecondsTimeout);
            a = pendingA;
            pendingA = null;
        }
        return new Message(a, b);
    }
