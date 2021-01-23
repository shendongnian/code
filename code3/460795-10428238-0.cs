    public static class DateHelper
    {
        public static DateTime NthOf(this DateTime CurDate, int Occurrence, DayOfWeek Day)
        {
            var fday = new DateTime(CurDate.Year, CurDate.Month, 1);
            var fOc = fday.DayOfWeek == Day ? fday : fday.AddDays(Day - fday.DayOfWeek);
            // CurDate = 2011.10.1 Occurance = 1, Day = Friday >> 2011.09.30 FIX. 
            if (fOc.Month < CurDate.Month) Occurrence = Occurrence + 1;
            return fOc.AddDays(7 * (Occurrence - 1));
        }
        public static bool IsThirdFridayInLastMonthOfQuarter(DateTime date)
        {
            // quarter ends
            int[] months = new int[] { 3, 6, 9, 12 };
            // if the date is not in the targeted months, return false.
            if (!months.Contains(date.Month))
                return false;
            DateTime thirdFriday = date.NthOf(3, DayOfWeek.Friday);
            return date.Date == thirdFriday.Date;
        }
    }
