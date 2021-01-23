    if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
    {
        var method = typeof(MyType).GetMethod("CountDuplicatesFast");
        var generic = method.MakeGenericMethod(typeof(T));
        return (int)generic.Invoke(null, new object[] { list });
    }
