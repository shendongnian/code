    public static class DateHelper
    {
        private int[] daysInMonth = new[] { 31, 28, 31, 30, 31, 30, 
                                            31, 31, 30, 31, 30, 31 };
        public static bool IsLeapYear(int year)
        {
            // TODO: taken from wikipedia, can be improved
            if (year % 400 == 0)
                return true;
            else if (year % 100 == 0)
                return false;
            else if (year % 4 == 0)
                return true;
            return false;
        }
        public static bool GetDaysInMonth(int year, int month)
        {
            // TODO: check for valid ranges
            var days = daysInMonth[month - 1];
            if (month == 2 && IsLeapYear(year))
                days++;
            return days;
        }
    }
