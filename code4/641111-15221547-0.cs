	public class ScheduleThread 
	{
		#region members and properties
		private readonly TimeSpan _timeSpan;
		private readonly Timer _timer;
		public bool IsRunning { get; protected set; }
		#endregion
	
		public ScheduleThread()
		{
			IsRunning = false;
			_timeSpan = new TimeSpan();//set the timespan according your config
			_timer = new Timer(CallBack);
		}
		#region Thread releted methods
		public void Start()
		{
			if (IsRunning == false)
			{
				IsRunning = true;
				StartTimer();
			}
		}
		private void StartTimer()
		{
			_timer.Change(_timeSpan, TimeSpan.Zero);
		}
		public void Stop()
		{
			if (IsRunning)
			{
				_timer.Stop();
				IsRunning = false;
			}
		}
		private void CallBack(object obj)
		{
			//if process is not running
			//start process
		} 		
	}
