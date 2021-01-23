    public TimeSpan ModifiedTime
    {
        get
        {
            TimeSpan elapsed = DateTime.Now - TimeStarted;
    		return TimeStarted.AddMinutes(elapsed.TotalSeconds);
        }
    }
