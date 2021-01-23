    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace PLinqTest
    {
        class Program
        {
            // This is our simulated "file". In essense it will contain the
            // ID of each Frame which has been processed and written to file.
            static readonly List<long> FrameFile = new List<long>();
            // This is a modification of Stephen Toub's Pipelines
            // example from Patterns Of Parallel Programming.
            private static async Task RunPipeline(VReader vreader, long totalframes)
            {
                var rawFrames = new BlockingCollection<Bitmap>();
                var processedFrames = new BlockingCollection<Bitmap>();
                // Stage 1: read raw frames.
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
                // Stage 2: process frames in parallel.
                var processTask = Task.Run(async () =>
                {
                    try
                    {
                        var degreesOfParallellism = Environment.ProcessorCount;
                        var consumingEnumerable = rawFrames.GetConsumingEnumerable();
                        // Start our parallel tasks.
                        while (true)
                        {
                            var tasks = consumingEnumerable
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
                // Stage 3: write results to file and dispose of the frame.
                var writeTask = Task.Run(() =>
                {
                    foreach (var processedFrame in processedFrames.GetConsumingEnumerable())
                    {
                        FrameFile.Add(processedFrame.ID);
                        processedFrame.Dispose();
                    }
                });
                await Task.WhenAll(readTask, processTask, writeTask);
            }
            // Sequential implementation - as is (for comparison).
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
                // Try both for comparison.
                //RunSequential(vreader, totalframes);
                RunPipeline(vreader, totalframes).Wait();
                sw.Stop();
                Console.WriteLine("Elapsed ms: {0}.", sw.ElapsedMilliseconds);
                // Validation: count, order and contents.
                var orderedFrames = Range(1, totalframes);
                if (orderedFrames.SequenceEqual(FrameFile))
                {
                    Console.WriteLine("Frame count, order and contents in the file is CORRECT.");
                }
                else
                {
                    Console.WriteLine("Frame count, order and contents in the file is INCORRECT.");
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
            private static IEnumerable<long> Range(long start, long count)
            {
                for (long i = start; i < start + count; i++)
                {
                    yield return i;
                }
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
                public readonly long ID;
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
    }
