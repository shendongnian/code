    //sealed so we don't have to implement full IDisposable pattern
    sealed class Q:IDisposable
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        private BlockingCollection<Action> queue =
            new BlockingCollection<Action>(new ConcurrentQueue<Action>());
    
        public Q()
        {
            new Thread(() => RunQueue()).Start();
        }
    
        private void RunQueue()
        {
            while(!cts.IsCancellationRequested)
            {
                Action action;
                try
                {
                    //lovely... blocks until something is available
                    //so we don't need to deal with messy synchronization
                    action = queue.Take(cts.Token); 
                }
                catch(OperationCanceledException)
                {
                    break;
                }
                action();
    		}
        }
    
        public void AddJob(Action action)
        {
            queue.Add(action,cts.Token);
        }
    
        public void Dispose()
        {
            if(!cts.IsCancellationRequested)
            {
                cts.Cancel();
            }
        }
    }
