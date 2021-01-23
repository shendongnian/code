    public struct TimeDuration
    {
        public DateTime FromTime { get; private set; }
        public DateTime ToTime { get; private set; }
        public TimeDuration(DateTime fromTime, DateTime toTime) : this()
        {
            FromTime = fromTime;
            ToTime = toTime;
        }
        public TimeDuration SetFromTime(DateTime fromTime)
        {
            var copy = this;
            copy.FromTime = fromTime;
            return copy;
        }
        public TimeDuration SetToTime(DateTime toTime)
        {
            var copy = this;
            copy.ToTime = toTime;
            return copy;
        }
    }
