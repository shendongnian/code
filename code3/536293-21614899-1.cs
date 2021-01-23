    public static void MultiplicateArray(double[] array, double factor)
    {
        var rangePartitioner = Partitioner.Create(0, array.Length);
        Parallel.ForEach(rangePartitioner, range =>
        {
            for (int i = range.Item1; i < range.Item2; i++)
            {
                array[i] = array[i] * factor;
            }
        });
    }
