    public class TaskQueue
    {
    	private Queue<Task> InnerTaskQueue;
             	
        private bool IsJobRunning;
    	public void Start()
    	{
    		Task.Factory.StartNew(() =>
    		{
    			while (true)
    			{
    				if (InnerTaskQueue.Count > 0 && !IsJobRunning)
    				{
    					 var task = InnerTaskQueue.Dequeue()
    					 task.Start();
                         IsJobRunning = true;
                         task.ContinueWith(t => IsJobRunning = false);
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
