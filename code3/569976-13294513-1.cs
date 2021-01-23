    private ConcurrentDictionary<string, int> _ids;
    private ConcurrentDictionary<string, Thread> _threads;
    private Task _producer;
    private Task _consumer;
    private CancellationTokenSource _cancellation;
    private void StartProducer()
    {
        _producer = Task.Factory.StartNew(() => 
           while (_cancellation.Token.IsCancellationRequested == false)
           {
               _ids.Add(GetNextKeyValuePair());
           }
       )
    }
    private void StartConsumer()
    {
        _consumer = Task.Factory.StartNew(() => 
           while (_cancellation.Token.IsCancellationRequested == false)
           {
               UseNextId(id);
               _ids.Remove(id);
           }
       )
    }
