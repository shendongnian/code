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
        if (e.Current.Keys.Length == 0)
        {
            throw new InvalidOperationException();
        }
        var length = e.Current.Keys.Length;
        result.Columns.AddRange(
            e.Current.Keys.Select(k => new DataColumn(k, typeof(T))).ToArray());
        do
        {
            if (e.Current.Values.Length != length)
            {
                throw new InvalidOperationException();
            }
            result.Rows.Add(e.Current.Values);
        }
        while (e.MoveNext());
        return result;
    } 
