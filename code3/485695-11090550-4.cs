    public static short? GetYearValue<T>(this T instance)
            {
                var propertyInfo = typeof(T).GetProperties().FirstOrDefault(m => m.CanRead && m.CanWrite && m.PropertyType == typeof(short?));
                return propertyInfo.GetValue(instance, null) as short?;
            }
