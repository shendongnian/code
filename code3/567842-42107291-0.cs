     public static object GetPropertyValue(this object o, string propertyName)
        {
            Type type = o.GetType();
            try
            {
                PropertyInfo info = (from x in  type.GetProperties() where x.Name.ToLower() == propertyName.ToLower() select x).First();
                object value = info.GetValue(o, null);
                return value;
            }
            catch (Exception ex)
            {
                return default(object);
            }
        }
        public static T GetFieldValue<T>(this object o, string propertyName) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            try
            {
                var val = GetPropertyValue(o, propertyName);
                return (T)val;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
