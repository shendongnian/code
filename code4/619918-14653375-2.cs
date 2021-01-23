    public TimeSpan TimeOfDay
    {
        get
        {
        	return new TimeSpan(this.InternalTicks % 864000000000L);
        }
    }
