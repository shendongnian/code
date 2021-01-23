    public static class Extensions
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<FieldInfo> fields = typeof(T).GetRuntimeFields().ToList();
            List<T> result = new List<T>();
            if (row.Table.Columns.Contains(field.Name))
            {
                foreach (var row in table.Rows)
                {
                    var item = CreateItemFromRow<T>((DataRow)row, fields);
                    result.Add(item);
                }
            }
    
            return result;
        }
    
        private static T CreateItemFromRow<T>(DataRow row, IList<FieldInfo> fields) where T : new()
        {
            T item = new T();
    
            foreach (var field in fields)
            {
                if (row[field.Name] == DBNull.Value)
                    field.SetValue(item, null);
                else
                    field.SetValue(item, row[field.Name]);
            }
            return item;
        }
    }
