    public static System.DateTime NptTimestampToDateTime(ref uint seconds, ref uint fractions, System.DateTime? epoch = null)
            {
                //Convert to ticks
                //ulong ticks = (ulong)((seconds * System.TimeSpan.TicksPerSecond) + ((fractions * System.TimeSpan.TicksPerSecond) / 0x100000000L)); //uint.MaxValue + 1
    
                unchecked
                {
                    //Convert to ticks,                 
    
                    //'UtcEpoch1900.AddTicks(seconds * System.TimeSpan.TicksPerSecond + ((long)(fractions * 1e+12))).Millisecond' threw an exception of type 'System.ArgumentOutOfRangeException'
    
                    //0.01 millisecond = 1e+7 picseconds = 10000 nanoseconds
                    //10000 nanoseconds = 10 micros = 10000000 pioseconds
                    //0.001 Centisecond = 10 Microsecond
                    //1 Tick = 0.1 Microsecond
                    //0.1 * 100 Nanos Per Tick = 100
                    //TenMicrosecondsPerPicosecond = 10000000 = TimeSpan.TicksPerSecond = 10000000 
                                                                                                //System.TimeSpan.TicksPerSecond is fine here also...
                    long ticks = seconds * System.TimeSpan.TicksPerSecond + ((long)(fractions * Media.Common.Extensions.TimeSpan.TimeSpanExtensions.TenMicrosecondsPerPicosecond) >> Common.Binary.BitsPerInteger);
                                              
                    //Return the result of adding the ticks to the epoch
                    //If the epoch was given then use that value otherwise determine the epoch based on the highest bit.
                    return epoch.HasValue ? epoch.Value.AddTicks(ticks) :
                            (seconds & 0x80000000L) == 0 ?
                                UtcEpoch2036.AddTicks(ticks) :
                                    UtcEpoch1900.AddTicks(ticks);
                }
            }
