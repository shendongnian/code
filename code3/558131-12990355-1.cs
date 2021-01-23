    foreach(A item in f.Collection)
    {
        Type itemType = item.GetType();
    
        if (typeof(B).IsAssignableFrom(itemType)
            DoSomethingB(item);
        else if (typeof(C).IsAssignableFrom(itemType)
            DoSomethingC(item);
        //...
    }
