    public class WeekendTester
    {
        public bool IsWeekendSoon()
        {
            return (int)DateTime.Now.DayOfWeek > 3;
        }
    }
