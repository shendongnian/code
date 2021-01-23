        public static class TimeHelper
        {
            // PRTime is Int64 count of microseconds from 1970-01-01-00-00-0000
            static Int64 ToPRTime(DateTime dateTime)
            {
                TimeSpan t = (dateTime - new DateTime(1970, 1, 1));
                return Convert.ToInt64(t.TotalMilliseconds * 1000);
            }
    
            static DateTime FromPrTime(Int64 prTime)
            {
                var someDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                var milliSeconds = prTime / 1000;
               return someDate.AddMilliseconds(milliSeconds);
            }
        }
