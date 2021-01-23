    public static bool IsDefault<T>( this T obj )
    {
        var t = typeof( T );
        var isNullable = t.IsGenericType && t.GetGenericTypeDefinition() == typeof( Nullable<> );
        // ...
    }
