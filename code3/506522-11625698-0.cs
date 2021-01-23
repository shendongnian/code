    [ThreadStatic]
    private static Wrapper instance;
    public static Wrapper Instance
    {
        get { return instance; }
    }
