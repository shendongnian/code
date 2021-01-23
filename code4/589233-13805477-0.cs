    public static class DateTimeExtensions
    {
        public static string ToAgo(this DateTime value)
        {
            DateTime now = DateTime.Now; //maybe UtcNow if you're into that
            if (value < now.AddMinutes(-1))
                return string.Format("{0} seconds ago", seconds);
            if (value < now.AddHours(-1))
                return string.Format("{0} minutes ago", minutes);
            // repeat for greater "ago" times...
        }
    }
