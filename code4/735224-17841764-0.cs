    interface IOneOrTwo { }
    interface IOne: IOneOrTwo { }
    interface ITwo: IOneOrTwo { }
    //*** This should now work fine ***
    public static IOneOrTwo Foo (this IOne obj, string arg)
    {
        // do something with arg
        return obj;     
    }
    //*** But this is more likely what you want ***
    public static IOneOrTwo Foo2 (this IOneOrTwo obj, string arg)
    {
        // do something with arg
        return obj:
    }
