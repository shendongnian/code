    int batchSize = 20;
    var batches = new Dictionary<int, List<SomeObject>>();
    for (int i = 0; i < sequence.Count; i++)
    {
        int batchNumber = i / batchSize;
        if (!batches.ContainsKey(batchNumber))
            batches.Add(batchNumber, new List<SomeObject>());
        batches[batchNumber].Add(sequence[i]);
    }
