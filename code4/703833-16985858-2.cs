    Expression<Func<AdStatsItem, int>>[] metricGetters = 
    {
        s => s.Impressions,
        s => s.Clicks,
        s => s.Spent,
    };
    // Cache this; don't create it each time.
    var updater = GetAggregateUpdater(metricGetters);
    var delta = new AdStatsItem
    {
        Impressions = 100,
        Clicks = 4,
        Spent = 33,
    };
    var hourly = new AdStatsItem
    {
        Impressions = 2000,
        Clicks = 140,
        Spent = 400,
    };
    updater(hourly, delta);
