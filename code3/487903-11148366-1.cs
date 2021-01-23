    public const string MarketDefault = "en-us";
    public static int CreateTaskGroup(string TaskGroupName,
        string Market = MarketDefault, ...)
    static void Main(string[] args)
    {
        CreateTaskGroup(
            args[0],
            args.ElementAtOrDefault(1) ?? MarketDefault,
            ...);
    }
