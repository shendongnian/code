	public class ScheduleThread 
	{
		private readonly TimeSpan _timeSpan;
		private readonly Timer _timer;
		public bool IsRunning { get; protected set; }	
		public ScheduleThread()
		{
			IsRunning = false;
                        //set the timespan according your config			
			_timeSpan = new TimeSpan();
		}
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
                        _timer = new Timer(CallBack);
			_timer.Change(_timeSpan, TimeSpan.Zero);
		}
		public void Stop()
		{
			if (IsRunning)
			{
				_timer.Dispose();
				IsRunning = false;
			}
		}
		private void CallBack(object obj)
		{
			//if process is not running
			//start process
		} 		
	}
