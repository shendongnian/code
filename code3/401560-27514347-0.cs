    public DateTime GetShiftedTimeStamp(DateTime timeStamp, int minutes)
    {
    	return
    		new DateTime(
    			Convert.ToInt64(
    				Math.Round(timeStamp.Ticks / (decimal)TimeSpan.FromMinutes(minutes).Ticks, 0, MidpointRounding.AwayFromZero)
    					* TimeSpan.FromMinutes(minutes).Ticks));
    }
