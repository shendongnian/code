    public void DoMultiOperations(Foo param, Action<IEnumerable<Bar>> callback)
    {
    	IList<Task> tasks = new List<Task>();
    
        // since each task's callback would access this storage - we are using
        // concurrent queue which is thread safe
        ConcurrentQueue<Bar> allResults = new ConcurrentQueue<Bar>();
    
    	foreach(var processor in this.processors)
    	{                
    	    Task task = new Task(() =>
    	        {
    	            IEnumerable<Bar> results = processor.Provide(param);
    	            foreach (var newItem in results)
    	            {
                        allResults.Enqueue(newItem);
    	            }
    	        });
    
            tasks.Add(task);                
    	}
    
        foreach (var task in tasks)
        {
            task.Start();
        }
    
        // 5 seconds or inject a value into this method
        int timeoutMilliseconds = 5000;
        Task.WaitAll(tasks.ToArray(), timeoutMilliseconds);
                
        callback(allResults);
    }
