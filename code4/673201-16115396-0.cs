            public void ParallelScraper(int fromInclusive, int toExclusive,
            Action<int> scrape, int desiredThreadsCount)
        {
            int chunkSize = (toExclusive - fromInclusive +
                desiredThreadsCount - 1) / desiredThreadsCount;
            ParallelOptions pOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = desiredThreadsCount
            };
            Parallel.ForEach(Partitioner.Create(fromInclusive, toExclusive, chunkSize),
                rng =>
                {
                    for (int i = rng.Item1; i < rng.Item2; i++)
                        scrape(i);
                });
        }
