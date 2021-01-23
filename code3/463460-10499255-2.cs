    IEnumerable<TimeInterval> ToHalfHourlyIntervals(
        IEnumerable<string> inputLines)
    {
        return
            from triple in TripleSplit(inputLines)
            select new TimeInterval
            {
                Start = DateTime.Parse(triple.Item1.Replace("Start: ", "")),
                End = DateTime.Parse(triple.Item2.Replace("End: ", "")),
                Value = Int32.Parse(triple.Item3)
            };
    }
