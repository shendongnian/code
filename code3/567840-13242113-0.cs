    // Add ' using System.Reflection; ' on top
    public static object GetPropertyValue(object o, string propertyName)
            {
                Type type = o.GetType();
                PropertyInfo info = type.GetProperty(propertyName);
                object value = info.GetValue(o, null);
                return value;
            }
