    public static IEnumerable<IEnumerable<T>> BatchAndSeparate<T>(IList<T> source, int batchSize)
    {
        int numBatches = (int)Math.Ceiling(source.Count / (double)batchSize);
    
        for (int i = 0; i < numBatches; i++)
        {
            var buffer = new List<T>();
            for (int j = i; j < source.Count; j += numBatches)
            {
                buffer.Add(source[j]);
            }
            yield return buffer;
        }
    }
