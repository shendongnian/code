    public static U Get<T, U>(this Dictionary<T, U> dict, T key)
        where U : class
    {
        T val;
        dict.TryGet(key, out val);
        return val;
    }
