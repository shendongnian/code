    public class MyQueue<T>
    {
    	private readonly Queue<T> internalQueue = new Queue<T>();
    	private readonly object queueLocker = new object();
    	
    	public Enqueue(T data)
    	{
    		internalQueue(data);
    	}
    	
    	public IDisposable LockingDequeue(out T data)
    	{
    		var queueLock = new QueueLock(queueLocker);
    		data = internalQueue.Dequeue();
    		return queueLock;
    	}
    
    	private class QueueLock :IDisposable
    	{
    		private readonly object lockObject;
    		
    		public QueueLock(object lockObject)
    		{
    			this.lockObject = lockObject;
    			Monitor.Enter(lockObject);
    		}
    		
    		public void Dispose()
    		{
    			Monitor.Exit(lockObject);
    		}
    	}
    }
