    int n = 100;
    int i = 3;
    int accum = 0;
    object logicLock = new object();
    void Main()
    {
    	// No point of having more tasks than available cores.
    	int maxTasks = 4;
    	Task[] tasks = new Task[maxTasks];
    	int count = 0;
    	Action taskAction = null;
    	taskAction = () => 
    		{
    			if(this.CheckCondition())
    			{
    				this.LoopLogic();
    				int index = count;
    				if(count == maxTasks)
    				{
    					Console.WriteLine("Waiting for a task");
    					index = Task.WaitAny(tasks);
    				} 
    				else
    				{
    					count++;
    				}
    				
    				Console.WriteLine("Executing a task");
    				tasks[index] = Task.Factory.StartNew(taskAction);
    			}
    			else
    			{
    				Console.WriteLine("Done");
    			}
    		};
    		
    	// Start looping
    	taskAction();
    	
    	// Wait for loops to finish
        while(CheckCondition()) 
        {
            Thread.Sleep(500);
        }
    }
    
    public void LoopLogic()
    {
    	lock(logicLock)
    	{
    		accum += i;
    	}
    }
    
    public bool CheckCondition()
    {
    	lock(logicLock)
    	{
    		return (n - accum) >= i;
    	}
    }
