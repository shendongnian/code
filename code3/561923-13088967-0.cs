    BlockingCollection<string> queue = new BlockingCollection<string>();    
    public void Start()
    {
        var producerWorker = Task.Factory.StartNew(() => ProducerImpl());
        var consumer1 = Task.Factory.StartNew(() => ConsumerImpl());
        var consumer2 = Task.Factory.StartNew(() => ConsumerImpl());
        var consumer3 = Task.Factory.StartNew(() => ConsumerImpl());
            
        Task.WaitAll(producerWorker, consumer1, consumer2, consumer3);
    }
        
    private void ProducerImpl()
    {
       // 1. Read a raw data from a file
       // 2. Preprocess it
       // 3. Add item to a queue
       queue.Add(item);
    }
    
    // ConsumerImpl must be thrad safe 
    // to allow launching multiple consumers simulteniously
    private void ConsumerImpl()
    {
        foreach (var item in queue.GetConsumingEnumerable())
        {
            // TODO
        }
    }
