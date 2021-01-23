    struct TimeRange
    {
        private readonly DateTime start;
        private readonly TimeSpan duration;
        public TimeRange ( DateTime start, TimeSpan duration )
        {
            this.start = start;
            this.duration = duration;
        }
	
        public DateTime From { get { return start; } }
	
        public DateTime To { get { return start + duration; } }
	
        public TimeSpan Duration { get { return duration; } }
	
        public IEnumerable<TimeRange> Split (TimeSpan subDuration)
        {
            for (DateTime subRangeStart = From; subRangeStart < this.To; subRangeStart += subDuration)
            {
                yield return new TimeRange(subRangeStart, subDuration);
            }
        }
	
        public override string ToString()
        {
            return String.Format ("{0} -> {1}", From, To);
        }
    }
