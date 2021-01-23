    List<DateTime> dates = new List<DateTime>();
    //Add dates
    for (int i = 1; i <= 28; i++) //days
        for (int j = 1; j <= 12; j++) //month
            for (int k = 1900; k <= 2013; k++) //year
                dates.Add(new DateTime(k, j, i, 1, 2, 3));
    double totalSec = 0;
    for (int i = 0; i < dates.Count; i++)
    {
        TimeSpan ts = dates[i].Subtract(DateTime.MinValue);
        totalSec += ts.TotalSeconds;
    }
    double averageSec = totalSec / dates.Count;
    DateTime averageDateTime = DateTime.MinValue.AddSeconds(averageSec);
    Console.WriteLine(averageDateTime.ToString("yyyy-MMM-dd HH:mm:ss"));
