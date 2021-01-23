    while (masterQueue.Count > 0)
    {
    	Queue<object[]> queue = masterQueue.Dequeue();
    
    	//Send Queue to an async Worker for processing...
    	tasks.Add(Process(queue));
    }
    
    // tasks are already in order
    Task.WaitAll(tasks.ToArray());
    
    ...
    async static Task Process(Queue<object[]> queue)
    {
    	await Task.Factory.StartNew(() => { });
    }
