    public static class DateTimeExtensions
    {
        public static string ToRelative(this DateTime value)
        {        
            DateTime now = DateTime.Now; //maybe UtcNow if you're into that
            TimeSpan span = new TimeSpan(now.Ticks - value.Ticks);
            double seconds = Math.Abs(ts.TotalSeconds);
            if (seconds < 60)
                return string.Format("{0} seconds ago", span.Seconds);
            if (seconds < 2700)
                return string.Format("{0} minutes ago", span.Minutes);
            if (seconds < 86400)
                return string.Format("{0} hours ago", span.Hours);
            // repeat for greater "ago" times...
        }
    }
