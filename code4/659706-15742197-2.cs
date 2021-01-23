    public static class EnumerableToDataTableConverter
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var newRow = dataTable.NewRow();
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    newRow[Props[i].Name] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(newRow);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
