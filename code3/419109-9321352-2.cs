    foreach (var old in oldCollection)
    {
        var condition = predicate(old);
        // ...
        {
            ctx.GetTable<T>().DeleteAllOnSubmit(ctx.GetTable<T>().Where(condition));
        }
    }
