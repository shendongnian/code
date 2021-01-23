    static long ntpEpoch = (new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).Ticks;
    static public long Ntp2Ticks(UInt64 a)
    {
      var b = (decimal)a * 1e7m / (1UL << 32);
      return (long)b + ntpEpoch;
    }
    static public UInt64 Ticks2Ntp(long a)
    {
    	decimal b = a - ntpEpoch;
    	b = (decimal)b / 1e7m * (1UL << 32);
    	return (UInt64)b;
    }
