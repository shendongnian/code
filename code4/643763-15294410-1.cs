    private static DataTable DictionariesToDataTable<T>(
            IEnumerable<IDictionary<string, T>> source)
    {
        if (source == null)
        {
            return null;
        }
        var result = new DataTable();
        var e = source.GetEnumerator();
        if (!e.MoveNext())
        {
            return result;
        }
        result.Columns.AddRange(
            e.Current.Keys.Select(k => new DataColumn(k, typeof(T))).ToArray());
        do
        {
            result.Rows.Add(e.Current.Values);
        }
        while (e.MoveNext());
        return result;
    } 
