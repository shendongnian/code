    static void My(double[] array, double factor)
    {
        int degreeOfParallelism = Environment.ProcessorCount;
        Parallel.For(0, degreeOfParallelism, workerId =>
        {
            var max = array.Length * (workerId + 1) / degreeOfParallelism;
            for (int i = array.Length * workerId / degreeOfParallelism; i < max; i++)
                array[i] = array[i] * factor;
        });
    }
