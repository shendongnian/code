    public static class TwitterExtensions
    {
        public static string MinutesAgo(this TwitterStatus status)
        {
            TimeSpan diff = DateTime.Now.Subtract(status.CreatedDate);
            return diff.Minutes.ToString() + "m";
        }
    }
