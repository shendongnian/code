	public class Job
	{
		private bool _isRunning = false;
		public bool IsRunning { get { return _isRunning; } }
		public void StartProcessing()
		{
			if (_isRunning)
			{	
				// TODO: warn?		
				return;
			}
			
			_isRunning = true;
			
			// do your thing
		}
		
		public void StopProcessing()
		{
			if (!_isRunning)
			{	
				// TODO: warn?
				return;
			}
		}
	}
