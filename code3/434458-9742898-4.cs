    public static IList<IList<T>> ConvertTo<T>(DataTable table)
    {
        if (table == null)
            return null;
        List<IList<T>> rows = new List<IList<T>>();
        foreach (DataRow row in table.Rows) {
            rows.Add(row.ItemArray.Cast<T>().ToArray());
        }
        return rows;
    }
