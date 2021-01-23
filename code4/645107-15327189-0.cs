    public static TimeSpan GetClosest(TimeSpan time, IEnumerable<TimeSpan> targets)
    {
        return targets.OrderBy(x => BestFit(x, time))).First();
    }
    private static long BestFit(TimeSpan x, TimeSpan y)
    {
        return Math.Min(Math.Abs((x - y).TotalTicks,
                        Math.Abs((x + TimeSpan.FromDays(1) - y).TotalTicks));
    }
