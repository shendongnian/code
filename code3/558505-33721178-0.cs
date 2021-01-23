            public static bool TimeBetween(DateTime time, DateTime startDateTime, DateTime endDateTime)
        {
            // get TimeSpan
            TimeSpan start = new TimeSpan(startDateTime.Hour, startDateTime.Minute, 0);
            TimeSpan end = new TimeSpan(endDateTime.Hour, endDateTime.Minute, 0);
            // convert datetime to a TimeSpan
            TimeSpan now = time.TimeOfDay;
            // see if start comes before end
            if (start < end)
                return start <= now && now <= end;
            // start is after end, so do the inverse comparison
            return !(end < now && now < start);
        }
