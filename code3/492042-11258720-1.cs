    foreach (var pair in crs.DocDictionary)
    {
        Console.WriteLine(pair.Key);
        Console.WriteLine(pair.Value.Id);
        Console.WriteLine(pair.Value.docType);
    }
