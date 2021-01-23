    public class ObjectUtils
    {
        public static object GetPropertyByName(object obj, string name)
        {
            if (obj == null)
            {
                return null;
            }
            PropertyInfo propInfo = obj.GetType().GetProperty(name);
            if (propInfo == null)
            {
                return null;
            }
            object value = propInfo.GetValue(obj, null);
            return value;
        }
    }
