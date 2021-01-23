    public static IList<T> GetItems<T>(DataTable table)
        where T : IDataObject, new()
    {
        var items = new List<T>();
        if (table != null) {
            foreach (DataRow row in table.Rows) {
                T item = new T();
                item.FillFromRow(row);
                items.Add(item);
            }
        }
        return items;
    }
