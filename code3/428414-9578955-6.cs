    var dbQuery = from bug in RawListData
                  group bug by new { bug.Category, bug.Priority } into grouped
                  select new { 
                      Category = grouped.Key.Category,
                      Priority = grouped.Key.Priority,
                      Count = grouped.Count()
                  };
    var query = dbQuery.ToLookup(result => result.Category,
                                 result => new { result.Priority, result.Count };
    foreach (var result in query)
    {
        Console.WriteLine("{0}: ", result.Key);
        foreach (var subresult in result)
        {
            Console.WriteLine("  {0}: {1}", subresult.Priority, subresult.Count);
        }
    }
