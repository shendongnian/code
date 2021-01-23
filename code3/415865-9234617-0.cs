    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    
    namespace Example
    {
    	public class TaskScheduler : IDisposable
    	{
    		private ConcurrentQueue<Func<bool>> PendingTasks;
    		private Thread ExecuterThread;
    		private volatile bool _IsDisposed;
    
    		public bool IsDisposed
    		{
    			get { return _IsDisposed; }
    		}
    
    		public void EnqueueTask(Func<bool> task)
    		{
    			PendingTasks.Enqueue(task);
    		}
    
    		public void Start()
    		{
    			CheckDisposed();
    
    			if (ExecuterThread != null)
    			{
    				throw new InvalidOperationException("The task scheduler is alreader running.");
    			}
    
    			ExecuterThread = new Thread(Run);
    			ExecuterThread.IsBackground = true;
    			ExecuterThread.Start();
    		}
    
    		private void CheckDisposed()
    		{
    			if (_IsDisposed)
    			{
    				throw new ObjectDisposedException("TaskScheduler");
    			}
    		}
    
    		private void Run()
    		{
    			while (!_IsDisposed)
    			{
    				Func<bool> task;
    				while (!PendingTasks.TryDequeue(out task))
    				{
    					Thread.Sleep(0);
    				}
    
    				if (!task.Invoke())
    				{
    					PendingTasks.Enqueue(task);
    				}
    			}
    		}
    
    		public void Dispose()
    		{
    			CheckDisposed();
    			_IsDisposed = true;
    		}
    	}
    }
