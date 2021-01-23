    private static TimeSpan RunAsParallelBatches(int inserts, int batchSize)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        List<List<int>> batches = new List<List<int>>();
        for (int g = 0; g < inserts / batchSize; g++)
        {
            List<int> numbers = new List<int>();
            int start = g * batchSize;
            int end = start + batchSize;
            for (int i = start; i < end; i++)
            {
                numbers.Add(i);
            }
            batches.Add(numbers);
        }
        Parallel.ForEach(batches,
            (batch) =>
            {
                using (DataClasses1DataContext ctx = new DataClasses1DataContext())
                {
                    foreach (int number in batch)
                    {
                        ctx.Tables.InsertOnSubmit(new Table() { Number = number });
                    }
                    ctx.SubmitChanges();
                }
            }
        );
        watch.Stop();
        return watch.Elapsed;
    }
