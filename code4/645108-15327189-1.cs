    public static TimeSpan GetClosest(TimeSpan time, IEnumerable<TimeSpan> targets)
    {
        return targets.MinBy(x => BestFit(x, time));
    }
    // BestFit as before
