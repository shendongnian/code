    if (sort.Column.Contains("Index"))
    {
        var func = Helpers.ExtensionMethods.CreateSelectorExpression<Divergence>(sort.Column);
    
        if (sort.Direction == SortDirection.Ascending)
        {
            return divergences.AsEnumerable().OrderBy(func.Invoke, new AlphanumComparator());
        }
        else
        {
            return divergences.AsEnumerable().OrderByDescending(func.Invoke, new AlphanumComparator());
        }
    }
