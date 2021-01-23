    SearchResult
        .Select(sr => sr.Category)
        .Distinct()
        .ToList()
        .ForEach(c => 
            Console.Out.WriteLine("Items in the " 
                                  + c 
                                  + " category include: " 
                                  + String.Join(",",
                                      SearchResult
                                         .Where(i => i.Category == c).Select(i => i.Item)))
    );
