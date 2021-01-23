    public void Produce(object o)
    {
      lock (_queueLock)
      {
        _queue.Enqueue(o);
        Monitor.Pulse(_queueLock);
      }
    }
