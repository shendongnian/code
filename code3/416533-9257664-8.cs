    int n = 100;
    int i = 3;
    int accum = 0;
    object logicLock = new object();
    Random rand = new Random();
    void Main()
    {
    	// No point of having more tasks than available cores.
    	int maxTasks = 4;
    	Task[] tasks = new Task[maxTasks];
    	int count = 0;
    	while(this.CheckCondition())
    	{
    		int index = count;
    		if(count++ >= maxTasks)
    		{
    			Console.WriteLine("Waiting for a task slot");
    			index = Task.WaitAny(tasks);
    		}
    		
    		Console.WriteLine("Executing a task in slot: {0}", index);
    		tasks[index] = Task.Factory.StartNew(LoopLogic);
    	}
    	
    	Console.WriteLine("Done");
    }
    
    public void LoopLogic()
    {
    	lock(logicLock)
    	{
    		accum += i;
    	}
    	
    	int sleepTime = rand.Next(0, 500);
    	Thread.Sleep(sleepTime);
    }
    
    public bool CheckCondition()
    {
    	lock(logicLock) 
    	{
    		return (n - accum) >= i;
    	}
    }
