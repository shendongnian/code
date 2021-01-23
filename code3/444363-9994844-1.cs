    public static class DateExtensions
    {
        public TimeSpan GetAge(this DateTime birthDate)
        {
            return DateTime.Now - birthDate;
        }
    }
