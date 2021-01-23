    foreach (var dbStatistic in dbStatistics)
    {
        Statistic statistic = new Statistic(dbStatistic.ID, dbStatistic.Statistic);
        statCollection.Add(statistic);
    }
