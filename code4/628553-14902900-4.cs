    void Main()
    {    
        foreach(var useParallel in new[]{false, true})
        {
            for(int batchSize = 1; batchSize < 1024; batchSize <<= 1)
            {
                var totalRunTime = TimeSpan.Zero;
                var sw = new Stopwatch();
                var runCount = 10;
                for(int run=0; run < runCount; run++)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    sw.Reset();
                    sw.Start();
                    var bmp = Bitmap.FromFile(@"c:\temp\banner.bmp") as Bitmap;
                    var hist = new Histogram();
                    hist.ComputeHistogram(bmp, useParallel, batchSize);
                    sw.Stop();
                    totalRunTime = totalRunTime.Add(sw.Elapsed);
                }
                Console.WriteLine("Parallel={0}, BatchSize={1} Avg={2} ms", useParallel, batchSize, totalRunTime.TotalMilliseconds / runCount);
            }        
        }
    }
