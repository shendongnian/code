    static class DateTimeExtensions
    {
        public static DateTime ExpiryDate(this DateTime dte)
        {
            return dte.AddMonths(ApplicationConfiguration.Rule3ExpiryLengthInMonths);
        }
    }
