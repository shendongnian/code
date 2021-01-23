    Result ViaPartition(double[] numbers)
    {
        var result = new Result();
        var rangePartitioner = Partitioner.Create(0, numbers.Length);
        Parallel.ForEach(rangePartitioner, (range, loopState) =>
        {
            var subtotal = new Result();
            for (int i = range.Item1; i < range.Item2; i++)
            {
                double n = numbers[i];
                subtotal.SumAll  += n;
                subtotal.SumAllQ += n*n;
            }
            lock (result)
            {
                result.SumAll  += subtotal.SumAll;
                result.SumAllQ += subtotal.SumAllQ;
            }
        });
        return result;
    }
