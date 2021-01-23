    static Action<AdStatsItem, AdStatsItem> GetAggregateUpdater
           (IEnumerable<Expression<Func<AdStatsItem, int>>> metricGetters)
    {
        var aggregate = Expression.Parameter(typeof(AdStatsItem), "aggregate");
        var delta = Expression.Parameter(typeof(AdStatsItem), "delta");
        var increments = from metricGetter in metricGetters
                         let memberExpression = (MemberExpression)metricGetter.Body
                         let property = (PropertyInfo)memberExpression.Member
                         select Expression.AddAssign
                                 (Expression.Property(aggregate, property),
                                  Expression.Property(delta, property));
        var lambda = Expression.Lambda<Action<AdStatsItem, AdStatsItem>>
                     (Expression.Block(increments), aggregate, delta);
        return lambda.Compile();
    }
