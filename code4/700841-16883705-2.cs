        // This is our simulated "file". In essense it will contain the
        // ID of each Frame which has been processed and written to file.
        static readonly List<int> FrameFile = new List<int>();
        // This is a modification of Stephen Toub's Pipelines
        // example from Patterns Of Parallel Programming.
        private static async Task RunPipeline(VReader vreader, long totalframes)
        {
            var rawFrames = new BlockingCollection<Bitmap>();
            var processedFrames = new BlockingCollection<Bitmap>();
            // Stage 1.
            var readTask = Task.Run(() =>
            {
                try
                {
                    for (long n = 0; n < totalframes; n++)
                    {
                        rawFrames.Add(vreader.ReadVideoFrame());
                    }
                }
                finally { rawFrames.CompleteAdding(); }
            });
            // Stage 2.
            var processTask = Task.Run(async () =>
            {
                try
                {
                    var degreesOfParallellism = Environment.ProcessorCount;
                    // Start our tasks.
                    while (true)
                    {
                        var tasks = rawFrames.GetConsumingEnumerable()
                            .Take(degreesOfParallellism)
                            .Select(frame => Task.Run(() => Process(frame)))
                            .ToArray();
                        if (tasks.Length == 0)
                        {
                            break;
                        }
                        await Task.WhenAll(tasks);
                        foreach (var t in tasks)
                        {
                            processedFrames.Add(t.Result);
                        }
                    }
                }
                finally { processedFrames.CompleteAdding(); }
            });
            // Stage 3.
            var writeTask = Task.Run(() =>
            {
                FrameFile.AddRange(processedFrames.GetConsumingEnumerable().Select(f => f.ID));
            });
            await Task.WhenAll(readTask, processTask, writeTask);
        }
        // Sequential implementation - as is.
        private static void RunSequential(VReader vreader, long totalframes)
        {
            for (long n = 0; n < totalframes; n++)
            {
                using (Bitmap frame = vreader.ReadVideoFrame())
                {
                    Process(frame);
                    WriteToFile(frame);
                }
            }
        }
        // Main entry point.
        static void Main(string[] args)
        {
            long totalframes = 1000;
            VReader vreader = new VReader();
            // We'll time our run.
            var sw = Stopwatch.StartNew();
            //RunSequential(vreader, totalframes);
            RunPipeline(vreader, totalframes).Wait();
            sw.Stop();
            Console.WriteLine("Elapsed ms: {0}.", sw.ElapsedMilliseconds);
            // Validation: count.
            if (FrameFile.LongCount() == totalframes)
            {
                Console.WriteLine("The count is correct.");
            }
            else
            {
                Console.WriteLine("The count is incorrect.");
            }
            // Validation: order.
            var orderedFrames = FrameFile.OrderBy(i => i).ToArray();
            if (orderedFrames.SequenceEqual(FrameFile))
            {
                Console.WriteLine("Frame order in the file is correct.");
            }
            else
            {
                Console.WriteLine("Frame order in the file is incorrect.");
            }
            Console.ReadLine();
        }
        private static Bitmap Process(Bitmap frame)
        {
            Thread.Sleep(10);
            return frame;
        }
        private static void WriteToFile(Bitmap frame)
        {
            Thread.Sleep(5);
            FrameFile.Add(frame.ID);
        }
        private class VReader
        {
            public Bitmap ReadVideoFrame()
            {
                return new Bitmap();
            }
        }
        private class Bitmap : IDisposable
        {
            private static int MaxID;
            public readonly int ID;
            public Bitmap()
            {
                this.ID = Interlocked.Increment(ref MaxID);
            }
            public void Dispose()
            {
                // Dummy method.
            }
        }
    }
