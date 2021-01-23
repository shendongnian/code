    public static class ExtensionClasses
    {
        public static string MinAgo(this TwitterStatus status)
        {
            TimeSpan diff = DateTime.Now.Subtract(status.CreatedDate);
            return diff.Minutes.ToString() + "m";
        }
    }
