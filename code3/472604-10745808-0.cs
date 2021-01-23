    public static Type GetNullableType(Type t)
    {
        if (t.IsClass) return t;
        else return typeof(Nullable<>).MakeGenericType(t);
    }
