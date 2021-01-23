    public static void ChunkProcess<T>(IEnumerable<T> source, int size, Action<IEnumerable<T>> action)
    {
        var chunk = source.Take(size);
        while (chunk.Any())
        {
            action(chunk);
            source = source.Skip(size);
            chunk = source.Take(size);
        }
    }
