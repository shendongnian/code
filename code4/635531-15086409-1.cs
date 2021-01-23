    public static class DateHelper
    {
        public static DateTime Min(DateTime date1, DateTime date2)
        {
            return (date1 < date2 ? date1 : date2);
        }
    }
