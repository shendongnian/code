    private readonly ConcurrentQueue<Item> _queue = new ConcurrentQueue<Item>();
    void ProducerThread()
    {
        while (ShouldRun) 
        { 
            Item item = GetNextItem();
            _queue.Enqueue(item);
            _signal.Set();
        }
    }
    void ConsumerThread()
    {
        while (ShouldRun)
        {
            _signal.Wait();
        
            Item item = null;
            while (_queue.TryDequeue(out item))
            {
               // do stuff
            }
        }
    }
    
