    public static class DateTimeExtensions
    {
        public static DateTime EquivalentWeekDay(this DateTime dtOld)
        {
            int num = (int)dtOld.DayOfWeek;
            int num2 = (int)DateTime.Today.DayOfWeek;
            return DateTime.Today.AddDays(num - num2);
        }
    }   
