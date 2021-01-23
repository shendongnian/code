    public static void AddIfNotNull<T,U>(this Dictionary<T,U> dic, T key, U value) where U : class {
        if (value != null) {
            dic.Add(key, value);
        }
    }
