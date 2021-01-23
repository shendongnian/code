    public static class CmpExtension
    {
        public static bool Cmp<T, TValue>(this T obj, string propertyName, TValue value)
            where TValue : class
        {
            var properties = obj.GetType().GetProperties()
                    .Where(p => p.CanRead);
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(obj, null);
                var childProperty = property.PropertyType.GetProperties()
                    .Where(p => p.CanRead)
                    .FirstOrDefault(p => p.Name == propertyName);
                if (childProperty == null) continue;
                var childPropertyValue = childProperty.GetValue(propertyValue, null);
                return childPropertyValue == value;
            }
            return false;
        }
    }
