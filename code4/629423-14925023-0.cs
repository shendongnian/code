    class TimeRange
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    class Schedule
    {
        private List<List<TimeRange>> Days = new List<List<TimeRange>>
        {
            new List<TimeRange>(), // Sunday
            new List<TimeRange>(), // Monday
            // etc.
        };
        public Add(DayOfWeek day, DateTime startTime, DateTime endTime);
        public Contains(DateTime test);
    }
