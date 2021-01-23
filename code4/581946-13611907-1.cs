    var batches = BatchAndSeparate(Enumerable.Range(1, 13).ToList(), 3);
    
    foreach (var batch in batches)
    {
        Console.WriteLine(string.Join(" ", batch));
    }
