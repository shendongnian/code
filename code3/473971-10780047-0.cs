    public static class IDictionaryExtensions
    {
        public static T? GetValue<T>(this IDictionary dictionary, object key) 
                      where T : struct
        {
            if (!dictionary.Contains(key))
                return null;
            object o = dictionary[key];
            if (o == null)
                return null;
            if (!(o is T))
                return null;
            return (T) o;
        }
        public static T GetValue<T>(this IDictionary dictionary, object key,
                                    T defaultValue) where T : struct
        {
            return dictionary.GetValue<T>(key) ?? defaultValue;
        }
    }
