    void Main()
    {
    	SynchronousTaskScheduler taskScheduler = new SynchronousTaskScheduler();
    	for (int i = 0; i < 100; i++)
    	{
    		Task.Factory.StartNew(() => SomeMethod(i), CancellationToken.None, TaskCreationOptions.None, taskScheduler);
    	}
    }
    
    void SomeMethod(int number)
    {
    	$"Scheduled task {number}".Dump();
    }
    
    // Define other methods and classes here
    class SynchronousTaskScheduler : TaskScheduler
    {
    	public override int MaximumConcurrencyLevel
    	{
    		get { return 1; }
    	}
    
    	protected override void QueueTask(Task task)
    	{
    		TryExecuteTask(task);
    	}
    
    	protected override bool TryExecuteTaskInline(
    		Task task,
    		bool taskWasPreviouslyQueued)
    	{
    		return TryExecuteTask(task);
    	}
    
    	protected override IEnumerable<Task> GetScheduledTasks()
    	{
    		return Enumerable.Empty<Task>();
    	}
}
