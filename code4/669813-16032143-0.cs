    namespace System
    {
    
    
        public static class TimeSpanExtensions
        {
    
    
            public static string ToMySQLstring(this DateTime dt)
            {
                int hour = dt.Hour + 1;
                int min = dt.Minute;
                int sec = dt.Second;
                int msec = dt.Millisecond;
    
                int day = dt.Day;
                int month = dt.Month;
                int year = dt.Year;
    
                //2009-05-01T14:18:12.430
                return String.Format("{0}-{1:00}-{2:00}T{3:00}:{4:00}:{5:00}.{6:000}", year, month, day, hour, min, sec, msec);
            }
    
    
        } // End Class
    
    
    } // End Namespace
