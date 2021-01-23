    int processed = 0, count = items.Count;
    List<List<int>> chunks = new List<List<int>>();
    foreach (int item in items)
    {
        int chunkIndex = processed++ / CHUNK_SIZE;
        if (chunks.Count == chunkIndex) {
            chunks.Add(new List<int>(CHUNK_SIZE));
        }
        chunks[chunkIndex].Add(item);
    }
