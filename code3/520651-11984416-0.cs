    public static void InvokeIfIsT<T>(object o, Action<T> action)
    {
        if (o is T)
           action((T)o);
    }
