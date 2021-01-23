    /// <summary>
    /// Converts the given tick count into a DateTime. Since TickCount rolls over after 24.9 days, 
    /// then every 49.7 days, it is assumed that the given tickCount occurrs in the past and is 
    /// within the last 49.7 days.
    /// </summary>
    /// <param name="tickCount">A tick count that has occurred in the past 49.7 days</param>
    /// <returns>The DateTime the given tick count occurred</returns>
    private DateTime ConvertTickToDateTime(int tickCount)
    {
    	// Get a reference point for the current time
    	int nowTick = Environment.TickCount;
    	DateTime currTime = DateTime.Now;
    	Int64 mSecElapsed = 0;
    	
    	// Check for overflow condition
    	if( tickCount < nowTick) // Then no overflow has occurred since the recorded tick
    	{
    		// MIN|--------------TC---------------0------------Now-------------|MAX
    		mSecElapsed = nowTick - tickCount;
    	}
    	else // tickCount >= currTick; Some overflow has occurred since the recorded tick
    	{
    		// MIN|--------------Now---------------0------------TC-------------|MAX
    		mSecElapsed = Convert.ToInt64((int.MaxValue - tickCount) + (nowTick + Math.Abs(Convert.ToDouble(int.MinValue))));   // Time BEFORE overflow + time since the overflow
    	}
    
    	DateTime tickCountAsDateTime = currTime - TimeSpan.FromMilliseconds(mSecElapsed);
    	return tickCountAsDateTime;        
    }
    
