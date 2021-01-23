    public static List<MyObject> CreateList(int items)
    {
        // Validate parmaeters.
        if (items < 0) 
            throw new ArgumentOutOfRangeException("items", items, 
                "The items parameter must be a non-negative value.");
    
        // Return the items in a list.
        return Enumerable.Range(0, items).
            Select(i => new MyObject { IntValue = i, DoubleValue = i }).
            ToList();
    }
