    private static bool IsIncluded
    {
        get
        {
            return (JsConfig.IncludeTypeInfo || JsConfig<T>.IncludeTypeInfo);
        }
    }
    private static bool IsExcluded
    {
        get
        {
            return (JsConfig.ExcludeTypeInfo || JsConfig<T>.ExcludeTypeInfo);
        }
    }
