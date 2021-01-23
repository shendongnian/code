    public static System.DateTime UtcEpoch2036 = new System.DateTime(2036, 2, 7, 6, 28, 16, System.DateTimeKind.Utc);
    public static System.DateTime UtcEpoch1900 = new System.DateTime(1900, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
     public static ulong DateTimeToNptTimestamp(ref System.DateTime value/*, bool randomize = false*/)
        {
            System.DateTime baseDate = value >= UtcEpoch2036 ? UtcEpoch2036 : UtcEpoch1900;
            System.TimeSpan elapsedTime = value > baseDate ? value.ToUniversalTime() - baseDate.ToUniversalTime() : baseDate.ToUniversalTime() - value.ToUniversalTime();
            //Media.Common.Extensions.TimeSpan.TimeSpanExtensions.MicrosecondsPerMillisecond = 1000
            //TicksPerPicosecond = 0.0000001m = 1e-7
            //4294967296 = uint.MaxValue + 1
            //0.001 == PicosecondsPerNanosecond = 1e-3            
            //429496.7296 Picoseconds = 4.294967296e-7 Seconds
            //4.294967296e-7 * 1000 Milliseconds per second = 0.0004294967296 * 1e+9 (PicosecondsPerMilisecond) = 429.4967296
            //0.4294967296 nanoseconds * 100 nanoseconds = 1 tick = 42.94967296 * 10000 ticks per millisecond = 429496.7296 / 1000 = 429.49672960000004
            unchecked
            {
                //return (ulong)((long)(elapsedTime.Ticks * 0.0000001m) << 32 | (long)((decimal)elapsedTime.TotalMilliseconds % 1000 * 4294967296m * 0.001m));
                //return (ulong)(((long)(elapsedTime.Ticks * 0.0000001m) << 32) + (elapsedTime.TotalMilliseconds % 1000 * 4294967296ul * 0.001));
                //return (ulong)(elapsedTime.Ticks * 1e-7 * 4294967296ul); //ie-7 * 4294967296ul = 429.4967296 has random diff which complies better? (In order to minimize bias and help make timestamps unpredictable to an intruder, the non - significant bits should be set to an unbiased random bit string.)
                //return (ulong)(elapsedTime.Ticks * 429.4967296m);//decimal precision is better but we still lose precision because of the magnitude? 0.001 msec dif ((ulong)(elapsedTime.Ticks * 429.4967296000000000429m))
                //429.49672960000004m has reliable 003 msec diff
                //Has 0 diff but causes fraction to be different from examples...
                //return (ulong)((elapsedTime.Ticks + 1) * 429.4967296m);
                //Also adding + 429ul;
                return (ulong)(elapsedTime.Ticks * 429.496729600000000000429m);
                //var ticks =  (ulong)(elapsedTime.Ticks * 429.496729600000000000429m); //Has 0 diff on .137 measures otherwise 0.001 msec or 1 tick, keeps the examples the same.
                //if(randomize) ticks ^= (ulong)(Utility.Random.Next() & byte.MaxValue);
                //return ticks;
            }
