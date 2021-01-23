    public static class MyDateTimeStringExtensions
    {
        public static DateTime ToDateTimeWithYear(this string source, int year)
        {
            var dateTime = DateTime.Parse(source);
            return dateTime.AddYears(year - dateTime.Year);
        }
    }
     ....
    "2/2".ToDateTimeWithYear(2001) // returns 2/2/2001 12:00:00 AM
