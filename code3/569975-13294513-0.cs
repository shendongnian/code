    private ConcurrentDictionary<string, int> _ids;
    private ConcurrentDictionary<string, Thread> _threads;
    private Task producer;
    private Task consumer;
    private CancellationTokenSource _cancellation;
    private void StartProducer()
    {
        producer = Task.Factory.StartNew(() => 
           while (_cancellation.Token.IsCancellationRequested == false)
           {
               _ids.Add(GetNextKeyValuePair());
           }
       )
    }
    private void StartConsumer()
    {
        consumer = Task.Factory.StartNew(() => 
           while (_cancellation.Token.IsCancellationRequested == false)
           {
               UseNextId(id);
               _ids.Remove(id);
           }
       )
    }
