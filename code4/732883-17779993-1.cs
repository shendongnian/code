    //Notice that I've added the generic paramters A and T.  It looks like you may 
    //have missed adding those parameters or you have specified too many types.
    public static A SomeAction<A, B, T>(IList<T> data) where T : IExportable, new()
    {
        T tType = new T();
        IList<B> BLists = SomeMethod(tType);
        //...
    } 
