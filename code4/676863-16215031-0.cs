    public static class DateTimeUtil
    {
        public static int YearsOld(this DateTime date)
        {
            DateTime now = DateTime.Now;
            var difference = now - date;
            return difference.Days / 365;
        }
    }
