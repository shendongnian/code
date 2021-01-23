    public static class MyExtensionFirADictionary
    {
       public static TValue GetGenericValue <TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key)
       { 
           TValue value;
           if (dic != null && dic.TryGetValue(key, out value))
               return value;
           return default(TValue);
       }
    }
