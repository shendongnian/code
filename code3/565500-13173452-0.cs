    abstract class Task
    {
        public readonly QueuedLock SyncObject = new QueuedLock();
    }
    
    Queue<Task> taskQueue = new Queue<Task>();
    Object queueLock = new Object();
    
    void TakeItemThreadedMethod()
    {
        Task task;
    	int ticket;
        lock(queueLock) 
    	{
    		task = taskQueue.Dequeue();
    		ticket = task.SyncObject.TakeTicket();
    	}
        task.SyncObject.Enter(ticket);
    	//Do some work here
        task.SyncObject.Exit();
    }
