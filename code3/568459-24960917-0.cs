    public static string GetMongoQuery<TItem>(this IQueryable<TItem> query)
    {
        var mongoQuery = query as MongoQueryable<TItem>;
        return mongoQuery == null ? null : mongoQuery.GetMongoQuery().ToString();
    }
