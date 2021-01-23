    if (parallel)
    {
        var batchSize = 2;
        System.Threading.Tasks.Parallel.For
        (
            0,
            height / batchSize,
            new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount },
            y =>
            {
                int startIndex = (stride * y * batchSize);
                int endIndex = startIndex + (stride * batchSize);
                for (int x = startIndex; x < endIndex; x += 4)
                {
                    // Interlocked actions are more-or-less atomic 
                    // (caveats abound, but this should work for us)
                    Interlocked.Increment(ref this.B[data[x]]);
                    Interlocked.Increment(ref this.G[data[x+1]]);
                    Interlocked.Increment(ref this.R[data[x+2]]);
                    Interlocked.Increment(ref this.A[data[x+3]]);
                }
            }
        );
    }
