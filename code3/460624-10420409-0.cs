    public static T GetValue<T>(string key)
    {
        object o;
        if (Contents.TryGetValue(key, out o))
        {
            if (o is T)
            {
                return (T)o;
            }
        }
        return default(T);
    }
