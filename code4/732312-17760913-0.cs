    public enum Months
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    public static class MonthsExtensions
    {
        public static int DaysInMonths(this Months month)
        {
            switch (month)
            {
                case Months.January:
                case Months.March:
                case Months.May:
                case Months.July:
                case Months.August:
                case Months.October:
                case Months.December:
                    return 31;
                case Months.April:
                case Months.June:
                case Months.September:
                case Months.November:
                    return 30;
                case Months.February:
                    return 28;
            }
            return 0;
        }
