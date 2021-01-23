    IEnumerable<String> lines = new List<string>();
    //or
    //IEnumerable<String> lines = Enumerable.Empty<string>();
    //IEnumerable<String> lines = Enumerable.Repeat("My string",1); //only single value
    //IEnumerable<String> lines = new string[] {"My string","My other string"}
    
    //or
    var lines = new List<string>();
    lines.Add("My string");
    lines.Add("My other string");   
 
    IEnumerable<String> ienumLines = lines;
    return ienumLines;
    //or add an extension method
    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items) 
    {
        foreach(T item in items) 
        {
           collection.Add(item);
        }
    }
