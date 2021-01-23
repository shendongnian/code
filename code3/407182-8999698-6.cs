    private readonly ConcurrentQueue<Item> _queue = new ConcurrentQueue<Item>();
    void ProducerThread()
    {
        while (ShouldRun) 
        { 
            Item item = GetNextItem();
            _queue.Enqueue(item);
            
            // more than 10 items? panic!
            // notify consumer immediately
            
            if (_queue.Count >= 10)
               _signal.Set();
        }
    }
    void ConsumerThread()
    {
        while (ShouldRun)
        {
            // wait for a signal, OR until
            // 10 seconds elapses
            _signal.Wait(TimeSpan.FromSeconds(10));
        
            Item item = null;
            while (_queue.TryDequeue(out item))
            {
               // do stuff
            }
        }
    }
