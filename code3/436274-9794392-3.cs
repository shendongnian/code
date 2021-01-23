            public static DateTime ToUserTimeZone(this DateTime utcDateTime, TimeZoneInfo currentTimeZone)
    		{
    			if (utcDateTime.Kind != DateTimeKind.Utc)
    			{
    				throw new ArgumentException("utcDateTime.Kind != DateTimeKind.Utc", "utcDateTime");
    			}
    
    			return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, currentTimeZone);
    		}
    
    		public static DateTime? ToUserTimeZone(this DateTime? utcDateTime, TimeZoneInfo currentTimeZone)
    		{
    			if (utcDateTime.HasValue)
    			{
    				return ToUserTimeZone(utcDateTime.Value, currentTimeZone);
    			}
    
    			return null;
    		}
