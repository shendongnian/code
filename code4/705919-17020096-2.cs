    public IEnumerable<DateTime> FirstAndLastTimesForEachDay(IEnumerable<DateTime> times)
    {
        DateTime previous = DateTime.MinValue;
        DateTime current  = DateTime.MinValue;
        foreach (var time in times)
        {
            if (previous.Date < time.Date)
            {
                if (previous != current)
                    yield return previous;
                yield return time;
                    
                current = time;
            }
            previous = time;
        }
        if (previous != current)
            yield return previous;
    }
