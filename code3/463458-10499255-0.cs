    class TimeInterval
    {
        DateTime Start;
        DateTime End;
        int Value;
    }
    IEnumerable<TimeInterval> ToHourlyIntervals(
        IEnunumerable<TimeInterval> halfHourlyIntervals)
    {
        return
            from pair in Split(halfHourlyIntervals)
            select new TimeInterval
            {
                Start = pair.Item1.Start,
                End = pair.Item2.End,
                Value = pair.Item1.Value + pair.Item2.Value
            };
    }
    static IEnumerable<Tuple<T, T>> Split<T>(
        IEnumerable<T> source)
    {
        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                T first = enumerator.Current;
                
                if (enumerator.MoveNext())
                {            
                    T second = enumerator.Current;
                    yield return Tuple.Create(first, second);
                }
            }
        }
    }
