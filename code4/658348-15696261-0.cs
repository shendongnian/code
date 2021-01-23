    public static T IsNull<T>(T v, T d) where T : class
    {
        return v ?? d;
    }
    public static T IsNull<T>(T? v, T d) where T : struct
    {
        return v.HasValue ? v.Value : d;
    }
