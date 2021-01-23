    public class User
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct LASTINPUTINFO
		{
			public uint cbSize;
			public uint dwTime;
		}
		[DllImport("user32.dll")]
		static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
		public static TimeSpan? GetInactiveTime()
		{
			LASTINPUTINFO info = new LASTINPUTINFO();
			info.cbSize = (uint)Marshal.SizeOf(info);
			if (GetLastInputInfo(ref info))
				return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime);
			else
				return null;
		}
		private TimeSpan? LastTime;
		private DispatcherTimer timer = new DispatcherTimer();
		public void RequestUserActivity()
		{
			LastTime = GetInactiveTime();
			timer.Interval = TimeSpan.FromMilliseconds(500);
			timer.Tick += timer_Tick;
			timer.Start();
		}
		void timer_Tick(object sender, EventArgs e)
		{
			TimeSpan? tmpTime = GetInactiveTime();
			if (LastTime.HasValue && tmpTime.HasValue && tmpTime < LastTime)
			{
				timer.Stop();
				UserAtivited(this, new EventArgs());
			}
			else if (!LastTime.HasValue || !tmpTime.HasValue)
			{
				timer.Stop();
				throw new Exception();
			}
		}
		public event EventHandler UserAtivited;
	}
