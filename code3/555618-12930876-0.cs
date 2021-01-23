    public static IOrderedEnumerable<T> Inspect<T>(this IOrderedEnumerable<T> source)
    {
        Console.WriteLine("In Ordered Inspect");
        // inspected items will be unordered
        Func<T, int> selector = item => { 
                  Console.WriteLine(item); 
                  return 0; };
                
        return source.CreateOrderedEnumerable(selector, null, false);    
    }
