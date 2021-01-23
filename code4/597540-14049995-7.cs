	public class Logger : IDisposable
	{
		private BlockingCollection<LogMessage> _messages = null;
		private Thread _worker = null;
		private bool _started = false;
		
		public void Start() 
		{
			if (_started) return;
			//Some logic to open log file
			OpenLogFile(); 		
			_messages = new BlockingCollection<LogMessage>();  //int.MaxValue is the default upper-bound
			_worker = new Thread(Work) { IsBackground = true };
			_worker.Start();
			_started = true;
		}
		
		public void Stop()
		{   
			if (!_started) return;
			
			// prohibit adding new messages to the queue, 
			// and cause TryTake to return false when the queue becomes empty.
			_messages.CompleteAdding();
			
			// Wait for the consumer's thread to finish.
			_worker.Join();  
			
			//Dispose managed resources
			_worker.Dispose();
			_messages.Dispose();
			
			//Some logic to close log file
			CloseLogFile(); 
			
			_started = false;
		}
		
		/// <summary>
		/// Implements IDiposable 
		/// In this case, it is simply an alias for Stop()
		/// </summary>
		void IDisposable.Dispose() 
		{
			Stop();
		}
		/// <summary>
		/// This is message consumer thread
		/// </summary>
		private void Work()
		{
			LogMessage message;
			//Try to get data from queue
			while(_messages.TryTake(out message, Timeout.Infinite))
				WriteLogMessage(message); //... some simple logic to write 'message'
		}
	}
