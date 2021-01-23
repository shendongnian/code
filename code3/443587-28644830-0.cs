	class CustomTimer : System.Timers.Timer
	{
		public string Data;
	}
	private void StartTimer()
	{
		var timer = new CustomTimer
		{
			Interval = 3000,
			Data = "Foo Bar"
		};
		timer.Elapsed += timer_Elapsed;
		timer.Start();
	}
	void timer_Elapsed(object sender, ElapsedEventArgs e)
	{
		string data = ((CustomTimer)sender).Data;
	}
