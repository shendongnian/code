    public static class PersainDate
    {
        public static DateTime ConvertToGregorian(this DateTime obj)
        {
            DateTime dt = new DateTime(obj.Year, obj.Month, obj.Day, new PersianCalendar());
            return dt;
        }
        public static DateTime ConvertToPersian(this DateTime obj)
        {
            var persian = new PersianCalendar();
            var year = persian.GetYear(obj);
            var month = persian.GetMonth(obj);
            var day = persian.GetDayOfMonth(obj);
            DateTime persiandate = new DateTime(year, month, day);
            return persianDate;
        }
    }
