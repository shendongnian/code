    // Disclaimer - from memory, not tested
    private static readonly long _ticksIn30Mins = TimeSpan.FromMinutes(30).Ticks;
    protected DateTime GetRoundedTime(DateTime inputTime) 
    {     
        long currentTicks = inputTime.Ticks;
        return new DateTime(currentTicks.RoundUp(_ticksIn30Mins)); 
    } 
    public static class ExtensionMethods 
    {     
        public static long RoundUp(this long i, long toTicks)     
        {         
            return (long)(Math.Round(i / (double)toTicks, 
                      MidpointRounding.AwayFromZero)) * toTicks; 
        } 
    } 
