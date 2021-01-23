    //This extension method is available to IOne, ITwo, and IOneOrTwo
    public static IOneOrTwo Foo2 (this IOneOrTwo obj, string arg)
    {
        // do something with arg
        return obj:
    }
    //This extension method is available only to IOne
    public static IOne Foo2 (this IOne obj, string arg)
    {
        // do something with arg
        return obj:
    }
    //This extension method is available only to ITwo
    public static ITwo Foo2 (this ITwo obj, string arg)
    {
        // do something with arg
        return obj:
    }
