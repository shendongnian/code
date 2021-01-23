	namespace System.Timers
	{
		/// <summary>
		/// Drop in Silverlight compatible replacement for the System.Timers.Timer
		/// Doesn't do synchronisation
		/// </summary>
		public class Timer
		{
			private readonly uint _interval;
			private System.Threading.Timer _internalTimer;
			private const uint MaxTime = (uint)0xFFFFFFFD;
			public event EventHandler<EventArgs> Elapsed;
			public Timer(uint interval)
			{
				_interval = interval;
			}
			public bool AutoReset { get; set; }        
			public void Start()
			{
				Stop();
				_internalTimer = CreateTimer();            
			}        
			public void Stop()
			{
				if (_internalTimer != null)
				{
					_internalTimer.Change(MaxTime, MaxTime);
					_internalTimer.Dispose();
					_internalTimer = null;
				}
			}
			private Threading.Timer CreateTimer()
			{
				var timer = new System.Threading.Timer(InternalTick);
				timer.Change(_interval, AutoReset ? _interval : MaxTime);
				return timer;
			}
			private void InternalTick(object state)
			{
				var handler = Elapsed;
				if (handler != null)
				{
					handler(this, EventArgs.Empty);
				}
			}
		}
	}
