    public class ActivityDay
    {
        public bool Active { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
    public class DailyActivityTime
    {
        public int WeeklyActivityTimeId { get; set; }
        public bool Biweekly { get; set; }
        public string DisplayText { get; set; }
        private ActivityDay[] _days = new ActivityDay[7];
        public ActivityDay this[int day]
        {
            get { return _days[day]; }
            set { _days[day] = value; }
        }
    }
