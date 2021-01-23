    public sealed class DateInterval
    {
        private readonly LocalDate start;
        private readonly LocalDate end;
        // TODO: Properties
        public DateInterval(LocalDate start, LocalDate end)
        {
            // TODO: Assert that end >= start, and that they use the same
            // calendar system
            this.start = start;
            this.end = end;
        }
        public bool IntersectsWith(DateInterval other)
        {
            // It intersects *unless* it's either completely before or completely
            // after *other*. There are other ways of representing this, but it's
            // the way that makes most intuitive sense to me.
            return !(this.end < other.start || this.start > other.end);
        }
    }
