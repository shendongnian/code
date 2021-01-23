    public IEnumerable<DateTime> FirstAndLastTimesForEachDay(IEnumerable<DateTime> times)
    {
        DateTime previous = DateTime.MinValue;
        foreach (var time in times)
        {
            if (previous.Date < time.Date)
            {
                if (previous != DateTime.MinValue)
                    yield return previous;
                yield return time;
            }
            previous = time;
        }
        if (previous != DateTime.MinValue)
            yield return previous;
    }
