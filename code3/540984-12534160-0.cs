    public MyList(IEnumerable<MyType> items)
    {
        if (items == null)
            throw new ArgumentNullException("items");
    
        foreach (var item in items)
            Add(item);
    }
