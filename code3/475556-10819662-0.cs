    public static IEnumerable<T> SomeOrAll<T>(
        this IEnumerable<T> source, 
        Predicate<T> where)
    {
        var results = source.Where(where)
        return results.Any() ? results : source;
    }
    var results = dt.AsEnumerable()
        .SomeOrAll(a.stringArray4.Contains([Col4]))
        .SomeOrAll(a.stringArray3.Contains([Col3]))
        .SomeOrAll(a.stringArray2.Contains([Col2]))
        .SomeOrAll(a.stringArray1.Contains([Col1]));
