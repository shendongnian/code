    void MyFunc<T>(T value)
    {
        Type t = typeof(T);
        if(t.IsEnum)
        {
            int valueAsInt = value.GetHashCode(); // returns the integer value
        }
    }
