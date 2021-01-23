    public static class DateTimeExtensions
    {
        public static DateTime Round(this DateTime self, double minutesInInterval)
        {
            if (minutesInInterval == 0d) throw new ArgumentOutOfRangeException("minutesInInterval");
            return self.AddMinutes(-self.TimeOfDay.TotalMinutes % minutesInInterval);
        }
    }
