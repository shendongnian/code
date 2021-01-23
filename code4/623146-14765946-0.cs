	public class SessionTimer : IDisposable
	{
		public static readonly ConcurrentDictionary<string, SessionTimer> Timers;
		private readonly Timer timer;
		static SessionTimer()
 		{
			Timers = new ConcurrentDictionary<string, SessionTimer>();
		}
		private SessionTimer(string connectionID)
		{
			ConnectionID = connectionID;
			timer = new Timer();
			timer.Interval = (double)Utility.ActivityTimerInterval();
			timer.Elapsed += (s, e) => MonitorElapsedTime();
			timer.Start();
		}
		private int TimeCount { get; set; }
		private string ConnectionID { get; set; }
		public static void StartTimer(string connectionID)
		{
			Timer newTimer = new SessionTimer(connectionID);
			if (!Timers.TryAdd(connectionID, newTimer))
			{
				newTimer.Dispose();
			}
		}
		public static void StopTimer(string connectionID)
		{
			Timer oldTimer;
			if (Timers.TryRemove(connectionID, out oldTimer))
			{
				oldTimer.Dispose();
			}
		}
		public void ResetTimer()
		{
			TimeCount = 0;
			timer.Stop();
			timer.Start();
		}
		public override Dispose()
		{
			// Stop might not be necessary since we call Dispose
			timer.Stop();
			timer.Dispose();
		}
		private void MonitorElapsedTime()
		{
			if (TimeCount >= Utility.TimerValue())
			{
				StopTimer(ConnectionID);
				Hubs.Notifier.SessionTimeOut(ConnectionID, TimeCount);
			}
			else
			{
				Hubs.Notifier.SendElapsedTime(ConnectionID, TimeCount);
			}
			TimeCount++;
		}
	}
