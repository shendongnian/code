    public static DataTable ToDataTable<T>(this IEnumerable<T> source, string newTableName)
    {
        DataTable newTable = new DataTable(newTableName);
        T firstRow = source.FirstOrDefault();
        if (firstRow != null)
        {
            PropertyInfo[] properties = firstRow.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                newTable.Columns.Add(prop.Name, prop.PropertyType);
            }
            foreach (T element in source)
            {
                DataRow newRow = newTable.NewRow();
                foreach (PropertyInfo prop in properties)
                {
                    newRow[prop.Name] = prop.GetValue(element, null);
                }
                newTable.Rows.Add(newRow);
            }
        }
        return newTable;
    }
