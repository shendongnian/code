    IEnumerable<object> GetPropertyValuesFlat(object o)
    {
        return o.GetType()
                .GetProperties()
                .Select(pi => pi.GetValue(item, null))
                .Where(pv => pv != null)
                .SelectMany(pv => pv is IEnumerable<object> ?
                              (IEnumerable<object>)pv : new[] {pv});
    }
    //...
    foreach (object p in GetPropertyValuesFlat(o))
        render(p);
