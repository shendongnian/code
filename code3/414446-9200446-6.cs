    public class mdbConcern
    {
        public Int32 ConcernId { get; set; }
        public String Concern { get; set; }
    
        public static PropertyDescriptor Mapping(string name)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(mdbConcern));
            switch (name)
            {
                case "Concern_Id":
                    return props.GetByName("ConcernId");
                case "Concern":
                    return props.GetByName("Concern");
                default:
                    return null;
            }
        }
    }
    
    public static class Helper
    {
        public static T ToType<T>(this DataRow row, Func<string, PropertyDescriptor> mapping) 
           where T : new()
        {
            T obj = new T();        
            foreach (DataColumn col in row.Table.Columns)
            {
                var prop = mapping(col.ColumnName);
                if(prop != null)
                    prop.SetValue(obj, row[col]);
            }
            return obj;
        }
    }
