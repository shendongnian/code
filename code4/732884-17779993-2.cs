    public static A SomeAction<B>(IList<T> data) where T : IExportable
    {
        //Notice what typeof returns.
        System.Type tType = typeof(T);
        IList<B> BLists = SomeMethod(tType);
        //...
    }  
