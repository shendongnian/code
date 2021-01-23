    public static TSource DoDictionaries<TSource, TValue>(TSource source, Func<TValue, TValue> cleanUpper)
        {
            Type type = typeof(TSource);
            PropertyInfo[] propertyInfos = type
                .GetProperties()
                .Where(info => info.PropertyType.IsGenericType &&
                               info.PropertyType.GetGenericTypeDefinition() == typeof (Dictionary<,>) &&
                               info.PropertyType.GetGenericArguments()[1] == typeof (TValue))
                .ToArray();
            foreach (var propertyInfo in propertyInfos)
            {
                var dict = (IDictionary)propertyInfo.GetValue(source, null);
                var newDict = (IDictionary)Activator.CreateInstance(propertyInfo.PropertyType);
                foreach (var key in dict.Keys)
                {
                    newDict[key] = cleanUpper((TValue)dict[key]);
                }
                propertyInfo.SetValue(source, newDict, null);
            }
            return source;
        }
