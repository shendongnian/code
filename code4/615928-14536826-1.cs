    long total = Products.LongCount();
    BlockingCollection<MyState> states = new BlockingCollection<MyState>();
    Parallel.ForEach(Products, () =>
    {
        MyState myState = new MyState();
        states.Add(myState);
        return myState;
    },
    (i, state, arg3, myState) =>
    {
        try
        {
            var price = GetPrice(SystemAccount, product);
            SavePrice(product,price);
        }
        finally
        {
            myState.value++;
            return myState;
        }
    },
    i => { }
    );
