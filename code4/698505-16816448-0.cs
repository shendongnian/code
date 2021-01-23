    static IEnumerable<DateTime> Spend(DateTime startTime, DateTime endTime, TimeSpan duration)
    {
        while (startTime <= endTime)
        {
            yield return startTime;
            startTime = startTime.Add(duration);
        }
    }
