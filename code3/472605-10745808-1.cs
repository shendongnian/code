    public static Type GetNullableType(Type t)
    {
        if (t.IsClass) return t;
        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>)) return t;
        else return typeof(Nullable<>).MakeGenericType(t);
    }
