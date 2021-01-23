    BlockingCollection<string> queue = new BlockingCollection<string>();
    
    public void Start()
    {
        var producerWorker = Task.Factory.StartNew(() => this.ProducerImpl());
        var consumerWorker = Task.Factory.StartNew(() => this.ConsumerImpl());
            
        Task.WaitAll(producerWorker, consumerWorker);
    }
        
    private void ProducerImpl()
    {
        int itemsCount = 100;
    
        while (itemsCount-- > 0)
        {
            queue.Add(itemsCount + " - " + Guid.NewGuid().ToString());
        }   
    }
    
    private void ConsumerImpl()
    {
        foreach (var item in queue.GetConsumingEnumerable())
        {
            // TODO
        }
    }
