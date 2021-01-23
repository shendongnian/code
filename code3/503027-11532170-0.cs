    private StopWatch _Sw = new StopWatch();
    private List<TimeSpan> _Samples = new List<TimeSpan>();
    private Timer _Timer = new Timer(TimerTick, TimeSpan.FromSeconds(1));
    private const int RequiredSamples = 100;
    
    private void StartSampling()
    {
    	// You can change this next line to PriorityClass.RealTime if you're careful.
    	System.Diagnostics.Process.GetCurrentProcess().BasePriority 
                                  = PriorityClass.High;
        _Samples.Capacity = RequiredSamples;
    	_Timer.Start();
    	_Sw.Start();
    	Hook555Timer(On555Pulse);
    }
    
    private void On555Pulse(object sender, EventArgs e)
    {
    	_Sample.Add(_Sw.Elapsed);
    }
    
    private void TimerTick(object sender, EventArgs e)
    {
    	if (_Samples.Count > RequiredSamples)
    	{
    		System.Diagnostics.Process.GetCurrentProcess().BasePriority 
                                        = PriorityClass.Normal;
    		_Timer.Stop();
    		_Sw.Stop();
    		UnHook555Timer(On555Pulse);
    		
    		// You can now use the time between each TimeSpan 
            // in _Samples to determine statistics about your timer.
    		// Eg: Min / Max duration, average and median duration.
    		var durations = _Samples
    				.Zip(_Samples.Skip(1), 
    					(a,b) => new { First = a, Second = b } )
    				.Select(pair => pair.Second.Subtract(pair.First));
    		var minTime = durations.Min(ts => ts.TotalMilliseconds);
    		var maxTime = durations.Max(ts => ts.TotalMilliseconds);
    		var averageTime = durations.Average(ts => ts.TotalMilliseconds);
    		// I don't think LINQ has a Median() aggregate out of the box.
    		// Some comment about "an exercise for the reader" goes here.
    		var medianTime = durations.Median(ts => ts.TotalMilliseconds);
    		
    		var frequency = _Samples.Last()
                                     .Subtract(_Samples.First())
                                          .TotalSeconds / _Samples.Count;
    	}
    }
