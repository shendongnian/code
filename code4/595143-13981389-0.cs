    public static class ObjectExtensions
    {
        public static object OptionalParam(this object value)
        {
            if (value == null) return DBNull.Value;
            var t = value.GetType();
        
            var defaultValue = t.IsValueType ? Activator.CreateInstance(t) : null;
            
            return value == defaultValue ? DBNull.Value : value;
        }
    }
