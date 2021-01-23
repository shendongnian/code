    public static IMongoQuery ToMongoQuery<T>(this IQueryable<T> linqQuery)
    {
        var mongoQuery = ((MongoQueryable<T>)linqQuery).GetMongoQuery();
        return mongoQuery;
    }
