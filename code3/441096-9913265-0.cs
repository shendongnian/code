    public class YourDbContext : DbContext
    {
        public void BulkInsert<T>(string tableName, IList<T> list)
        {
            using (var bulkCopy = new SqlBulkCopy(base.Database.Connection))
            {
                bulkCopy.BatchSize = list.Count;
                bulkCopy.DestinationTableName = tableName;
                var table = new DataTable();
                var props = TypeDescriptor.GetProperties(typeof(T))
                              // Dirty hack to make sure we only have system 
                              // data types (i.e. filter out the 
                              // relationships/collections)
                              .Cast<PropertyDescriptor>()
                              .Where(p => "System" == p.PropertyType.Namespace)
                              .ToArray();
                foreach (var prop in props)
                {
                    bulkCopy.ColumnMappings.Add(prop.Name, prop.Name);
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) 
                               ?? prop.PropertyType;
                    table.Columns.Add(prop.Name, type);
                }
                var values = new object[props.Length];
                foreach (var item in list)
                {
                    for (var i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                bulkCopy.WriteToServer(table);
            }
        }
    }
