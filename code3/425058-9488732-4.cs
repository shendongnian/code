    public class WeekendTester
    {
        private readonly Func<DateTime> _dateTimeProvider;
        public WeekendTester(Func<DateTime> dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
    
        public bool IsWeekendSoon()
        {
            return (int)_dateTimeProvider().DayOfWeek > 3;
        }
    }
