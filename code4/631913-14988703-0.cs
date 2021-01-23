    Message WrapA(int a, int millisecondsTimeout)
    {
        bool lockTaken = false;
        int? b = null;
        try
        {
            Monitor.TryEnter(gate, millisecondsTimeout, ref lockTaken);
            if (lockTaken)
            {
                if (pendingB != null)
                {
                    b = pendingB;
                    pendingB = null;
                    Monitor.Pulse(gate);
                }
            }
        }
        finally
        {
            if (lockTaken)
            {
                Monitor.Exit(gate);
            }
        }
        return new Message(a, b);
    }
    Message WrapB(int b, int millisecondsTimeout)
    {
        bool lockTaken = false;
        try
        {
            TimeoutHelper timeout = new TimeoutHelper(millisecondsTimeout);
            Monitor.TryEnter(gate, timeout.RemainingTime(), ref lockTaken);
            if (lockTaken)
            {
                if (pendingB == null)
                {
                    pendingB = b;
                    Monitor.Wait(gate, timeout.RemainingTime());
                    if (pendingB == null) return null;
                    pendingB = null;
                }
                else
                {
                    Monitor.Pulse(gate);
                    try { }
                    finally { lockTaken = false; Monitor.Exit(gate); }
                    Thread.Sleep(1);
                    Monitor.TryEnter(gate, timeout.RemainingTime(), ref lockTaken);
                    if (lockTaken)
                    {
                        if (pendingB == null)
                        {
                            pendingB = b;
                            Monitor.Wait(gate, timeout.RemainingTime());
                            if (pendingB == null) return null;
                            pendingB = null;
                        }
                    }
                }
            }
        }
        finally
        {
            if (lockTaken)
            {
                Monitor.Exit(gate);
            }
        }
        return new Message(null, b);
    }
