    foreach (System.Linq.IGrouping<object[], T> g in collection.GroupBy(
        new Func<T, object[]>(
            item => selectors.Select(sel => sel.Compile().Invoke(item)).ToArray()
        ),
        new ColumnComparer()
    )
    { ... }
