    int[] Source = Enumerable.Range(0, 1000).ToArray();
    int i = 0;
    int ChunkSize = 100;
    var Result = Source.GroupBy(s => i++ / ChunkSize).Select(g => g.ToArray());
    
