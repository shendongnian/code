    foreach (string toFind in searchString)     
    {
       var searchResults = dt.AsEnumerable()  
                             .Where(a => a.Field<string>("A")
                                          .ToUpper()
                                          .Contains(toFind.ToUpper())
                            .Select(a => new object[] {
                                               a.Field<Int32("A"),
                                               a.Field<string>("B"),
                                               a.Field<string>("C")
                             })
                            .ForEach(re => results.Rows.Add(re));
    }
    // ForEach() extension method would help you adding rows to a data table
    // in the same time as querying the results
    public static void ForEach<T>(
        this IEnumerable<T> source,
        Action<T> action)
    {
        foreach (T element in source) 
            action(element);
    }
