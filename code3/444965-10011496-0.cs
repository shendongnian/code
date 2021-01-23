	class TimerTest
	{
		private DateTime _start = DateTime.Now;
		private Timer _timer = new Timer(1000);
		
		public TimerTest()
		{
			// (DateTime.Now - _start) returns a TimeSpan object
			// Default TimeSpan.ToString() returns 00:00:00
			_timer.Elapsed = (o, e) => labelUpTime.Text = (DateTime.Now - _start).ToString();
		}
	}
