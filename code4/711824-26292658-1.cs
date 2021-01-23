    var inputLines = new BlockingCollection<string>();
    ConcurrentDictionary<int, int> catalog = new ConcurrentDictionary<int, int>();
    
    var readLines = Task.Factory.StartNew(() =>
    {
        foreach (var line in File.ReadLines(catalogPath)) 
            inputLines.Add(line);
    
            inputLines.CompleteAdding(); 
    });
    
    var processLines = Task.Factory.StartNew(() =>
    {
        Parallel.ForEach(inputLines.GetConsumingEnumerable(), line =>
        {
            string[] lineFields = line.Split('\t');
            int genomicId = int.Parse(lineFields[3]);
            int taxId = int.Parse(lineFields[0]);
            catalog.TryAdd(genomicId, taxId);   
        });
    });
    
    Task.WaitAll(readLines, processLines);
