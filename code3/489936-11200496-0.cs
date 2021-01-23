    private static readonly Dictionary<MyEnum, string> _dict =
    {
        //Using dictionary initialization
        {MyEnum.MyValue, "The text for MyValue"},
        {MyEnum.MyOtherValue, "Some other text"},
        {MyEnum.YetAnotherValue, "Something else"}
    }
    public static readonly Dictionary<MyEnum, string> Dict
    {
        get
        {
            return _dict;
        }
    }
