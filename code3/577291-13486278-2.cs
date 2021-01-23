    	public class ThreadingSample : IDisposable
	{
		private Queue<SomeObject> _processingQueue = new Queue<SomeObject>();
		private Thread _worker;
		private volatile bool _workerTerminateSignal = false;
		private EventWaitHandle _waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
		public bool HasQueuedItem
		{
			get
			{
				lock(_processingQueue)
				{
					return _processingQueue.Any();
				}
			}
		}
		public SomeObject NextQueuedItem
		{
			get
			{
				if ( !HasQueuedItem )
					return null;
				lock(_processingQueue)
				{
					return _processingQueue.Dequeue();
				}
			}
		}
		public void AddItem(SomeObject item)
		{
			lock(_processingQueue)
			{
				_processingQueue.Enqueue(item);
			}
			_waitHandle.Set();
		}
		public ThreadingSample()
		{
			_worker = new Thread(ProcessQueue);
			_worker.Start();
		}
		private void ProcessQueue()
		{
			while(!_workerTerminateSignal)
			{
				if ( !HasQueuedItem )
				{
					Console.WriteLine("No items, waiting.");
					_waitHandle.WaitOne();
					Console.WriteLine("Waking up...");
				}
				var item = NextQueuedItem;
				if (item != null)	// Item can be missing if woken up when the worker is being cleaned up and closed.
					Console.WriteLine(string.Format("Worker processing item: {0}", item.Data));
			}
		}
		public void Dispose()
		{
			if (_worker != null)
			{
				_workerTerminateSignal = true;
				_waitHandle.Set();
				if ( !_worker.Join( TimeSpan.FromMinutes( 1 ) ) )
				{
					Console.WriteLine("Worker busy, aborting the thread.");
					_worker.Abort();
				}
				_worker = null;
			}
		}
		public class SomeObject
		{
			public string Data
			{
				get;
				set;
			}
		}
	}
