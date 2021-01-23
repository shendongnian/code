    foreach (var old in oldCollection)
    {
        var condition = predicate(old);
        if (!newCollection.Any(condition.Compile()))
        {
            ctx.GetTable<T>().DeleteAllOnSubmit(ctx.GetTable<T>().Where(condition));
        }
    }
