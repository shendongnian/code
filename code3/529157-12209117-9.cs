    public class Job
    {
        public TimeSpan STARTTIME;
        public TimeSpan ENDTIME;
        public DayOfWeek taskDayOfWeek;
        public bool IsEndingTommorow;
        public bool IsTomorrow(DayOfWeek d)
        {
            if (d == DayOfWeek.Sunday)
                return taskDayOfWeek == DayOfWeek.Saturday;
            else
                return d <= taskDayOfWeek;
        }
    }
