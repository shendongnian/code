    interface IOneOrTwo { }
    interface IOne: IOneOrTwo { }
    interface ITwo: IOneOrTwo { }
    //*** This should now work fine ***
    public static IOneOrTwo Foo (this IOne obj, string arg)
    {
        // do something with arg
        return obj;     
    }
