    public static class DateConstructionExtensions
    {
        public static DateTime January(this int day, int year)
        {
            return new DateTime(year, /* month: */1, day);
        }
        // equivalent methods for February, March, etc...
    }
