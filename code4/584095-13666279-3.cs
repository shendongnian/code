    public class TaskTracker
    {
	    private readonly Action OnDoWork;
		private Task _task;
        private bool _isRunning = true;
        public TaskTracker(Guid identity, Action onDoWork)
        {
            Identity = identity;
			OnDoWork = onDoWork;
        }
        public readonly Guid Identity;
        public readonly Stopwatch Stopwatch = new Stopwatch();
        public void Run()
        {
		    Task _task = Task.Factory.StartNew(
				() =>
				    {
						Stopwatch.Start();
						try
						{
							while (_isRunning)
							{
								OnDoWork();
							}
						}
						finally
						{
							Stopwatch.Stop();
						}
					}
			    );
        }
        public void Stop()
        {
            _isRunning = false;
			// wait for task to exit?
			_task = null;
        }
    }
