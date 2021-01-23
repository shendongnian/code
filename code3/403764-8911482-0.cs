    // Disclaimer - from memory, not tested
    private static readonly long _ticksIn30Mins = TimeSpan.FromMinutes(30).Ticks;
    protected DateTime GetStartTime() 
    {     
        long currentTicks = Time.Now.Ticks;
        return new DateTime(currentTicks.RoundUp(_ticksIn30Mins)); 
    } 
    public static class ExtensionMethods 
    {     
        public static long RoundUp(this long i, long toTicks)     
        {         
            return (long)(Math.Round(i / (double)toTicks, 
                      MidpointRoundingMode.AwayFromZero)) * toTicks; 
        } 
    } 
