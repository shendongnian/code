    public static class ReflectionHelpers
    {
        public static bool TrySetProperty<TValue>(this object obj, string propertyName, TValue value)
        {
            var property = obj.GetType()
                .GetProperties()
                .Where(p => p.CanWrite && p.PropertyType == typeof(TValue))
                .FirstOrDefault(p => p.Name == propertyName);
            if (property == null)
            {
                return false;
            }
            property.SetValue(obj, value);
            return true;
        }
        public static bool TryGetPropertyValue<TProperty>(this object obj, string propertyName, out TProperty value)
        {
            var property = obj.GetType()
                .GetProperties()
                .Where(p => p.CanRead && p.PropertyType == typeof(TProperty))
                .FirstOrDefault(p => p.Name == propertyName);
            if (property == null)
            {
                value = default(TProperty);
                return false;
            }
            value = (TProperty) property.GetValue(obj);
            return true;
        }
    }
