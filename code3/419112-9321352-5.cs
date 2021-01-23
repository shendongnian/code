    public static void CudOperation<T>(this DataContext ctx,
        IEnumerable<T> oldCollection,
        IEnumerable<T> newCollection,
        Expression<Func<T, T, bool>> predicate)
        where T : class
    {
        var compiled = predicate.Compile();
        foreach (var old in oldCollection)
        {
            if (!newCollection.Any(o => compiled(o, old)))
            {
                var applied = PartialApplier.PartialApply(predicate, old);
                ctx.GetTable<T>().DeleteAllOnSubmit(ctx.GetTable<T>().Where(applied));
            }
        }
        foreach (var newItem in newCollection)
        {
            var existingItem = oldCollection.SingleOrDefault(o => compiled(o, newItem));
            if (existingItem != null)
            {
                ctx.GetTable<T>().Attach(newItem, existingItem);
            }
            else
            {
                ctx.GetTable<T>().InsertOnSubmit(newItem);
            }
        }
    }
