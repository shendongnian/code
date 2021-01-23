    public static T[] InitializeAll<T>(this T[] source) where T : new()
    {
        if(source != null)
        {
            for(var i = 0; i < source.Length; ++i)
            {
                source[i] = new T();
            }
        }
        return source;
    }
    var test2 = new MyClass[5].InitializeAll();
