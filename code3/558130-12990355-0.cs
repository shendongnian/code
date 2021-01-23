    foreach(A item in f.Collection)
    {
        Type itemType = item.GetType();
    
        if (typeof(B).IsAssignableFrom(itemType)
            DoSomething((B)item);
        else if (typeof(C).IsAssignableFrom(itemType)
            DoSomething((C)item);
        //...
    }
