    double totalSec = 0;
    for (int i = 0; i < dates.Count; i++)
    {
        TimeSpan ts = dates[i].Subtract(DateTime.MinValue);
        totalSec += ts.TotalSeconds;
    }
    double averageSec = totalSec / dates.Count;
    DateTime averageDateTime = DateTime.MinValue.AddSeconds(averageSec);
