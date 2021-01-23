    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnMappingAttribute : Attribute
    {
        public string Name { get; set; }
        public ColumnMappingAttribute(string name)
        {
            Name = name;
        }
    }
    public class mdbConcern
    {
        ColumnMapping("Concern_Id")]
        public Int32 ConcernId { get; set; }
        ColumnMapping("Concern")]
        public String Concern { get; set; }
    }
    
    public static class Helper
    {   
        public static T ToType<T>(this DataRow row) where T : new()
        {
            T obj = new T();
            var props = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor prop in props)
            {
                var columnMapping = prop.Attributes.OfType<ColumnMappingAttribute>().FirstOrDefault();
                
                if(columnMapping != null)
                {
                    if(row.Table.Columns.IndexOf(columnMapping.Name) >= 0 
                        && row[columnMapping.Name].GetType() == prop.PropertyType)
                    {               
                        prop.SetValue(obj, row[columnMapping.Name]);
                    }
                }
            }
            return obj;
        }
    }
