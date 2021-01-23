	public class Worker
	{
		private Dispatcher _appDispatcher = Dispatcher.CurrentDispatcher;
		private Dispatcher _workerDispatcher;
		private Thread _workerThread;
		
		public Worker()
		{
			_workerThread = new Thread(RunWorkerThread);
			_workerThread.Start();
		}
		
		public void RunBehind(Action a_action, Action a_callback)
		{
			_workerDispatcher.BeginInvoke(new Action(() =>
			{
				a_action();
				_appDispatcher.BeginInvoke(a_callback);
			}));
		}
		private void RunWorkerThread()
		{
			Thread.CurrentThread.Name = "AppWorker";
			_workerDispatcher = Dispatcher.CurrentDispatcher;
			Dispatcher.Run();
		}
	}
