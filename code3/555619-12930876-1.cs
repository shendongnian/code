    public static IOrderedEnumerable<T> Inspect<T>(this IOrderedEnumerable<T> source)
    {
        Console.WriteLine("In Ordered Inspect");            
        var enumerable = source.CreateOrderedEnumerable(x => 0, null, false);    
        // each time you apply Inspect all query until this operator will be executed
        foreach(var item in enumerable)
            Console.WriteLine(item);
        return enumerable;    
    }
