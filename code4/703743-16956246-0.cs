    public static class DateTimeExtension
    {
        public static DateTime DefaultSqlDateTime(this DateTime dateTime)
        {
           return new DateTime(1753, 1, 1, 12, 0, 0);
        }
    }
