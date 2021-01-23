    public static void ProcessObject<T>(T x)
    {
        object o;
        if (typeof(T) == typeof(int))
            o = GetObject((int)(object)x);
        else if (typeof(T) == typeof(string))
            o = GetObject((string)(object)x);
        else
            throw new Exception();
        // do stuff with o
    }
