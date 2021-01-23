    public class NonGenericBase
    {
        private static Dictionary<string, IEnumerable<object>> cachedList = new Dictionary<string, IEnumerable<object>>();
 
        protected static IEnumerable<T> GetCachedList<T>(string key) {
            return (IEnumerable<T>)cachedList[key];
        }
 
        protected static void SetCachedList<T>(string key, IEnumerable<T> value)
            where T : class
        {
            cachedList[key] = (IEnumerable<object>)value;
        }
    }
