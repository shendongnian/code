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
			ProcessFile();
		}
		
		public void StopProcessing()
		{
			if (!_isRunning)
			{	
				// TODO: warn?
				return;
			}
			// TODO: stop processing
		}
		private void ProcessFile()
		{
			_isRunning = true;
			// do your thing
			_isRunning = false;
		}
	}
