	// Declare singleton wrapper of a stopwatch, which instantiates stopwatch
	// on construction
	public class StopwatchProxy 
	{
		private Stopwatch _stopwatch;
		private static readonly StopwatchProxy _stopwatchProxy = new StopwatchProxy();
		private StopwatchProxy()
		{
			_stopwatch = new Stopwatch();
		}
		public Stopwatch Stopwatch { get { return _stopwatch; } } 
		public static StopwatchProxy Instance
		{ 
			get { return _stopwatchProxy; }
		}
	}
	// Use singleton
	class Foo
	{
		void Foo()
		{
			// Stopwatch instance here
			StopwatchProxy.Instance.Stopwatch.Start();
		}
	}
	class Bar
	{
		void Bar()
		{
			// Is the same instance as here
			StopwatchProxy.Instance.Stopwatch.Stop();
		}
	}
