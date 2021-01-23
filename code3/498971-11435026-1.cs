    public void DoMultiOperations(Foo param, Action<IEnumerable<Bar>> callback)
    {
    	// since each task's callback would access this storage - we are using
        // one of the concurrent queue
        ConcurrentQueue<Bar> allResults = new ConcurrentQueue<Bar>();
    
        Task[] tasks = this.processors.Select(p => new Task(() =>
            {
                IEnumerable<Bar> results = p.Provide(param);
                foreach (var newItem in results)
                {
                    allResults.Enqueue(newItem);
                }
            })).ToArray();
        
        foreach (var task in tasks)
        {
            task.Start();
        }
    
        // 5 seconds to wait or inject a value into this method
        Task.WaitAll(tasks, 5000);                
        callback(allResults);
    }
