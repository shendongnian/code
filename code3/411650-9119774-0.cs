    // Code as before...
    dynamic dyn = grouped;
    ShowGrouping(dyn);
    
    private static void ShowGrouping<TKey, TValue>
       (IEnumerable<IGrouping<TKey, TValue>> grouping)
    {
        Console.WriteLine("TKey = {0}, TValue = {1}", typeof(TKey), typeof(TValue));
    }
    
    private static void ShowGrouping(object notGrouped)
    {
        Console.WriteLine("Not a grouping");
    }
