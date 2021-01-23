    public static class Helper
    {
        public static T ToType<T>(this DataRow row) where T : new()
        {
            T obj = new T();
            var props = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor prop in props)
            {
                if(row.Table.Columns.IndexOf(prop.Name) >= 0 
                    && row[prop.Name].GetType() == prop.PropertyType)
                {   
                    prop.SetValue(obj, row[prop.Name]);
                }
            }
            return obj;
        }
    }
