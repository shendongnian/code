    using (MongoDbContext dbContext = new MongoDbContext(_dbFactory))
    {
        var query = new QueryDocument();
        var cursor =
            dbContext.Set<TEntity>().Find(query).SetSortOrder(SortBy.Descending("ModifiedDateTime")).SetLimit(5);
        foreach (TEntity entity in cursor)
        {
            entities.Add(entity);
        }
    }
