	using System;
	using System.Threading;
	Timer _timer = null;
	_timer = new Timer(o =>
		{
			methodToBeScheduled();
		});
	_timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(60));
