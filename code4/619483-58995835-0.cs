    void Main()
    {
    	var t1 = new Task(() => Console.WriteLine("hello, I'm task t1"));
    	t1.ContinueWith(t => CreateAndRunASubTask(), TaskScheduler.FromCurrentSynchronizationContext());
    	t1.Start();
    	
    	Console.WriteLine("All tasks done with");
    }
    
    // Define other methods and classes here
    public void CreateAndRunASubTask()
    {
    	var tsk = new Task(() => Console.WriteLine("hello, I'm the sub-task"));
    	tsk.Start();
    	Console.WriteLine("sub-task has been told to start");
    	tsk.Wait();
        // the code blocks on tsk.Wait() indefinately, the tsk status being "WaitingToRun"
    	Console.WriteLine("sub-task has finished");
    }
