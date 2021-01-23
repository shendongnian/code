    public static Type GetNullableType(Type t)
    {
        if (t.IsValueType && (Nullable.GetUnderlyingType(t) == null)) 
            return typeof(Nullable<>).MakeGenericType(t); 
        else
            return t;
    }
