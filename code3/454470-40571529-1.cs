    public static IMongoQuery ToMongoQuery<T>(this IQueryable<T> linqQuery)
    {
        var mongoQuery = ((MongoQueryable<T>)linqQuery).GetMongoQuery();
        return mongoQuery;
    }
    public static WriteConcernResult Delete<T>(this MongoCollection<T> col,   IQueryable<T> linqQuery)
    {
         return col.Remove(linqQuery.ToMongoQuery());
    }
    public static WriteConcernResult Delete<T>(this MongoCollection<T> col, Expression<System.Func<T, bool>> predicate)
    {
        return col.Remove(col.AsQueryable<T>().Where(predicate).ToMongoQuery());
    }
