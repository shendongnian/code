    private static Convert(IEnumerable<IDictionary<string, int>> source)
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
            e.Current.Keys.Select(k => new DataColumn(k, typeof(int))).ToArray());
        do
        {
            result.Rows.Add(e.Current.Values);
        }
        while (e.MoveNext());
        return result;
    } 
