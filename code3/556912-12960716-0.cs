    public static Expression<Func<MyEntity, bool>> HasPrefix(String prefix) 
    { 
        return e => e.RowKey.CompareTo(prefix + '_') > 0 && e.RowKey.CompareTo(prefix + '`') <= 0;
    }
    CloudTableQuery<MyEntity> query =
        (from e in Context.CreateQuery<MyEntity>(tablename)
        where e.PartitionKey == "KnownPartition"
        select e)
        .Where(HasPrefix("Prefix"))
        .AsTableServiceQuery();
 
