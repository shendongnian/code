    private readonly object _lock = new object();
    private readonly Queue<Item> _queue = new Queue<Item>();
    private readonly AutoResetEvent _signal = new AutoResetEvent();
    
    void ProducerThread()
    {
        while (ShouldRun) 
        { 
            Item item = GetNextItem();
            
            // you need to make sure only
            // one thread can access the list
            // at a time
            lock (_lock)
            {
                _queue.Enqueue(item);
            }
            
            // notify the waiting thread
            _signal.Set();
        }
    }
