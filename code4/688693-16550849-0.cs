    public static class DateTimeExtensionMethods
    {
            /// <summary>
            /// Returns the first day of the month for the given date.
            /// </summary>
            /// <param name="self">"this" date</param>
            /// <returns>DateTime representing the first day of the month</returns>
            public static DateTime FirstDayOfMonth(this DateTime self)
            {
                return new DateTime(self.Year, self.Month, 1, self.Hour, self.Minute, self.Second, self.Millisecond);
            }   // eo FirstDayOfMonth
    
    
            /// <summary>
            /// Returns the last day of the month for the given date.
            /// </summary>
            /// <param name="self">"this" date</param>
            /// <returns>DateTime representing the last of the month</returns>
            public static DateTime LastDayOfMonth(this DateTime self)
            {
                return FirstDayOfMonth(self.AddMonths(1)).AddDays(-1);
            }   // eo LastDayOfMonth
    }
