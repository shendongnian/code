    private DataTable ToDataTable<T>(T entity) where T : class
    {
       var properties = typeof(T).GetProperties();
       var table = new DataTable();
       foreach(var property in properties)
       {
           table.Columns.Add(property.Name, property.PropertyType);
       }
       table.Rows.Add(properties.Select(p => p.GetValue(entity, null)).ToArray());
       return table;
   }
