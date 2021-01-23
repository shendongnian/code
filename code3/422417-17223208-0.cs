    interface IGenericFunc
    {
        TResult Call<TArg,TResult>(TArg arg);
    }
    // ... in some class:
    void Test(IGenericFunc genericFunc)
    {
        // for example's sake only:
        int x = genericFunc.Call<String, int>("string");
        object y = genericFunc.Call<double, object>(2.3);
    }
