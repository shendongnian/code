    public class TaskQueue
    {
    	private Queue<Task> InnerTaskQueue;
    	
    	public void Start()
    	{
    		Task.Factory.StartNew(() =>
    		{
    			while (true)
    			{
    				if (InnerTaskQueue.Count > 0)
    				{
    					 var task = InnerTaskQueue.Dequeue()
    					 task.Start();
    				}
    				else
    				{
    					 Thread.Sleep(1000);
    				}
    			}
    		}
    	}
    
    	public Task<T> QueueJob(Func<T> job)
    	{
    		var task = new Task<T>(() => job());
    		InnerTaskQueue.Enqueue(task);
    		return task;
    	}
    }
