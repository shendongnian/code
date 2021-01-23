    public static class DateTimeExtensions
    {
        static DateTime SQL_DEFAULT = new DateTime(1900, 1, 1);
        public static bool IsDefaultValue(this DateTime dateTime)
        {
            return dateTime == SQL_DEFAULT;
        }
    }
