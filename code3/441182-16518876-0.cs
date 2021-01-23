        /// <summary>
        /// Removes a timespan from a date, returning MinValue or MaxValue instead of throwing exception when if the resulting date
        /// is behind the Min/Max values
        /// </summary>
        /// <returns></returns>
        public static DateTime SafeAdd(this DateTime source, TimeSpan value)
        {
            // Add or remove ?
            if (value.Ticks > 0)
            {
                // add
                var maxTicksToAdd = DateTime.MaxValue - source;
                if (value.Ticks > maxTicksToAdd.Ticks)
                    return DateTime.MaxValue;
            }
            else
            {
                var maxTicksToRemove = source - DateTime.MinValue;
                 
                // get the value to remove in unsigned representation.
                // negating MinValues is impossible because it would result in a value bigger than MaxValue : (-32768 .. 0 .. 32767)
                var absValue = value == TimeSpan.MinValue ? TimeSpan.MaxValue : -value;
                if (absValue.Ticks > maxTicksToRemove.Ticks)
                    return DateTime.MinValue;
            }
            return source + value;
        }
    
