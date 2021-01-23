    static class ExptensionFunction
    {
        static T GetValueAs<T>(this Dictionary<string, object> obj, string key)
        {
            return (T)obj[key];
        }
        static bool TryGetValueAs<T>(this Dictionary<string, object> d, string key, out T value)
        {
            object id;
            if (d.TryGetValue(key, out id))
            {
                if (id is T)
                {
                    value = (T)id;
                    return true;
                }
            }
            value = default(T);
            return false;
        }
        static IEnumerable<Dictionary<string, object>> GetValuesWithKey<T>(this List<Dictionary<string, object>> list, string key, T value)
        {
            return list.Where(d =>
            {
                T id;
                if (d.TryGetValueAs<T>(key, out id))
                {
                    return id.Equals(value);
                }
                return false;
            });
        }
    }
