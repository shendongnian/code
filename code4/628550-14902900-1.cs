    public void ComputeHistogram (byte[] data, int stride, int height, bool parallel = false)
    {
        this.Initialize();
        if (parallel)
        {
            System.Threading.Tasks.Parallel.For
            (
                0,
                height,
                new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount },
                y =>
                {
                    int startIndex = (stride * y);
                    int endIndex = stride * (y+1);
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
        else
        {
            // the original way is ok for non-parallel, since only one
            // thread is mucking around with the data
        }
        // Sorry, couldn't help myself, this just looked "cleaner" to me
        this.MaxA = this.A.Max();
        this.MaxR = this.R.Max();
        this.MaxG = this.G.Max();
        this.MaxB = this.B.Max();
        this.MaxT = new[] { this.MaxA, this.MaxB, this.MaxG, this.MaxR }.Max();
    }
