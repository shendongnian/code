    public static List<Interval> Merge(List<Interval> intervals)
    {
        var mergedIntervals = new List<Interval>();
        var orderedIntervals = intervals.OrderBy<Interval, DateTime>(x => x.Start).ToList<Interval>();
        DateTime start = orderedIntervals.First().Start;
        DateTime end = orderedIntervals.First().End;
        Interval currentInterval;
        for (int i = 1; i < orderedIntervals.Count; i++)
        {
            currentInterval = orderedIntervals[i];
            if (currentInterval.Start < end)
            {
                end = currentInterval.End;
            }
            else
            {
                mergedIntervals.Add(new Interval()
                {
                    Start = start,
                    End = end
                });
                start = currentInterval.Start;
                end = currentInterval.End;
            }
        }
        mergedIntervals.Add(new Interval()
                    {
                        Start = start,
                        End = end
                    });
        return mergedIntervals;
    }
