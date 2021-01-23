    var collection = Enumerable.Range(-5, 11)
        .Select(x => new { Original = x, Square = x * x })
        .Inspect()
        .OrderBy(x => x.Square)
        .Inspect()
        //.ThenBy(x => x.Original)
        ;
    foreach (var element in collection)
    {
        Console.WriteLine(element);
    }
...
    public static IEnumerable<T> Inspect<T> (this IOrderedEnumerable<T> source)
    {
        Console.WriteLine ("In Inspect (ordered)");
        foreach(T item in source){
            Console.WriteLine(item);
            yield return item;
        }
    }
