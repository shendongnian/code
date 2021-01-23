    private const int batchSize = 1048576;
    private static int[] GetDefaultSeriesArray2(int size, int value)
    {
    
        int[] result = new int[size];
    
        //fill the first batch normally
        int end = Math.Min(batchSize, size);
        for (int i = 0; i < end; i++)
        {
            result[i] = value;
        }
    
        int numBatches = size / batchSize;
    
        Parallel.For(1, numBatches, batch =>
        {
            Array.Copy(result, 0, result, batch * batchSize, batchSize);
        });
    
        //handle partial leftover batch
        for (int i = numBatches * batchSize; i < size; i++)
        {
            result[i] = value;
        }
    
        return result;
    }
