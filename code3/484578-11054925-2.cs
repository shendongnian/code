		private const long MILLISECOND_IN_MINUTE = 60 * 1000;
		private const long TICKS_IN_MILLISECOND = 10000;
		private const long TICKS_IN_MINUTE = MILLISECOND_IN_MINUTE * TICKS_IN_MILLISECOND;
		private System.Timers.Timer timer;
		private long nextIntervalTick;
		public void frmMain()
		{
			timer = new System.Timers.Timer();
			timer.AutoReset = false;
			timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
			timer.Interval = GetInitialInterval();
			timer.Start();
		}
		private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
			timer.Interval = GetInterval();
			timer.Start();
		}
		private double GetInitialInterval()
		{
			DateTime now = DateTime.Now;
			double timeToNextMin = ((60 - now.Second) * 1000 - now.Millisecond);
			nextIntervalTick = now.Ticks + ((long)timeToNextMin * TICKS_IN_MILLISECOND);
			return timeToNextMin;
		}
		private double GetInterval()
		{
			nextIntervalTick += TICKS_IN_MINUTE;
			return TicksToMs(nextIntervalTick - DateTime.Now.Ticks);
		}
		private double TicksToMs(long ticks)
		{
			return (double)(ticks / TICKS_IN_MILLISECOND);
		}
