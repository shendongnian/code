    var query = from bug in RawListData
                group bug by new bug.Category into grouped
                select new { 
                    Category = grouped.Category,
                    Counts = from bug in grouped
                             group bug by grouped.Priority into g2
                             select new { Priority = g2.Key, Count = g2.Count() }
                };
    foreach (var result in query)
    {
        Console.WriteLine("{0}: ", result.Category);
        foreach (var subresult in result.Counts)
        {
            Console.WriteLine("  {0}: {1}", subresult.Priority, subresult.Count);
        }
    }
