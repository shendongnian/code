    void Main()
    {
    	var stage1Queue = new BlockingCollection<object>(new ConcurrentQueue<object>());
    	var stage2Queue = new BlockingCollection<object>(new ConcurrentQueue<object>());
    	var stage3Queue = new BlockingCollection<object>(new ConcurrentQueue<object>());
    	
    	var threads = new Thread[] {new Thread(() => Stage1Worker(stage1Queue, stage2Queue)),
    							    new Thread(() => Stage2Worker(stage2Queue, stage3Queue)),
    							    new Thread(() => Stage3Worker(stage3Queue))
    							   };
    							   
    	foreach (var thread in threads) thread.Start();
    	
    	stage1Queue.Add("*");
    	stage1Queue.Add("*");
    	stage1Queue.Add("*");
    	
    	Console.ReadKey();
    }
    
    public void Stage1Worker(BlockingCollection<object> queue, BlockingCollection<object> next)
    {
    	foreach (var task in queue)
    	{
    		Console.WriteLine(task); // do work here, even mutating task if needed
    		next.TryAdd(task.ToString() + "*"); // will always succeed for a ConcurrentQueue
    	}
    }
    
    public void Stage2Worker(BlockingCollection<object> queue, BlockingCollection<object> next)
    {
    	foreach (var task in queue)
    	{
    		Console.WriteLine(task); // do work here, even mutating task if needed
    		next.TryAdd(task.ToString() + "*"); // will always succeed for a ConcurrentQueue
    	}
    }
    
    public void Stage3Worker(BlockingCollection<object> queue)
    {
    	foreach (var task in queue)
    	{
    		Console.WriteLine(task); // do work here, even mutating task if needed
    		// no more work!
    	}
    }
