    private static int DistinctCount<TItems, TProperty>(IEnumerable<TItems> items,
                                                        string property,
                                                        IEqualityComparer<TProperty> propertyComparer)
    {
        var propertyInfo = typeof(TItems).GetProperty(property);
        return items.Select(x => (TProperty)propertyInfo.GetValue(x, null))
                                     .Distinct(propertyComparer).Count();
    }
