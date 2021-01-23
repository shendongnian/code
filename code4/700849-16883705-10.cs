    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace PipelineExample
    {
        /// <summary>
        /// Stack Overflow question 16882318.
        /// </summary>
        public class Program
        {
            /// <summary>
            /// This is our simulated "file". In essense it will contain the
            /// ID of each Frame which has been processed and written to file.
            /// </summary> 
            private static readonly List<long> FrameFile = new List<long>();
            /// <summary>
            /// This is a modification of Stephen Toub's Pipelines
            /// example from Patterns Of Parallel Programming.
            /// </summary>
            private static void RunPipeline(VReader vreader, long totalframes)
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
                var processTask = Task.Run(() =>
                {
                    try
                    {
                        // Try both - see which performs better in your scenario.
                        Step2WithParallelTasks(rawFrames, processedFrames);
                        //Step2WithPLinq(rawFrames, processedFrames);
                    }
                    finally { processedFrames.CompleteAdding(); }
                });
                // Stage 3: write results to file and dispose of the frame.
                var writeTask = Task.Run(() =>
                {
                    foreach (var processedFrame in processedFrames.GetConsumingEnumerable())
                    {
                        WriteToFile(processedFrame);
                        processedFrame.Dispose();
                    }
                });
                Task.WaitAll(readTask, processTask, writeTask);
            }
            /// <summary>
            /// Processes frames in rawFrames and adds them to
            /// processedFrames preserving the original frame order.
            /// </summary>
            private static void Step2WithPLinq(BlockingCollection<Bitmap> rawFrames, BlockingCollection<Bitmap> processedFrames)
            {
                Console.WriteLine("Executing Step 2 via PLinq.");
                var processed = rawFrames.GetConsumingEnumerable()
                    .AsParallel()
                    .AsOrdered()
                    .Select(frame =>
                    {
                        Process(frame);
                        return frame;
                    });
                foreach (var frame in processed)
                {
                    processedFrames.Add(frame);
                }
            }
            /// <summary>
            /// Processes frames in rawFrames and adds them to
            /// processedFrames preserving the original frame order.
            /// </summary>
            private static void Step2WithParallelTasks(BlockingCollection<Bitmap> rawFrames, BlockingCollection<Bitmap> processedFrames)
            {
                Console.WriteLine("Executing Step 2 via parallel tasks.");
                var degreesOfParallellism = Environment.ProcessorCount;
                var inbox = rawFrames.GetConsumingEnumerable();
                // Start our parallel tasks.
                while (true)
                {
                    var tasks = inbox
                        .Take(degreesOfParallellism)
                        .Select(frame => Task.Run(() =>
                        {
                            Process(frame);
                            return frame;
                        }))
                        .ToArray();
                    if (tasks.Length == 0)
                    {
                        break;
                    }
                    Task.WaitAll(tasks);
                    foreach (var t in tasks)
                    {
                        processedFrames.Add(t.Result);
                    }
                }
            }
            /// <summary>
            /// Sequential implementation - as is (for comparison).
            /// </summary>
            private static void RunSequential(VReader vreader, long totalframes)
            {
                for (long n = 0; n < totalframes; n++)
                {
                    using (var frame = vreader.ReadVideoFrame())
                    {
                        Process(frame);
                        WriteToFile(frame);
                    }
                }
            }
            /// <summary>
            /// Main entry point.
            /// </summary>
            private static void Main(string[] args)
            {
                // Arguments.
                long totalframes = 1000;
                var vreader = new VReader();
                // We'll time our run.
                var sw = Stopwatch.StartNew();
                // Try both for comparison.
                //RunSequential(vreader, totalframes);
                RunPipeline(vreader, totalframes);
                sw.Stop();
                Console.WriteLine("Elapsed ms: {0}.", sw.ElapsedMilliseconds);
                // Validation: count, order and contents.
                if (Range(1, totalframes).SequenceEqual(FrameFile))
                {
                    Console.WriteLine("Frame count and order of frames in the file are CORRECT.");
                }
                else
                {
                    Console.WriteLine("Frame count and order of frames in the file are INCORRECT.");
                }
                Console.ReadLine();
            }
            /// <summary>
            /// Simulate CPU work.
            /// </summary>
            private static void Process(Bitmap frame)
            {
                Thread.Sleep(10);
            }
            /// <summary>
            /// Simulate IO pressure.
            /// </summary>
            private static void WriteToFile(Bitmap frame)
            {
                Thread.Sleep(5);
                FrameFile.Add(frame.ID);
            }
            /// <summary>
            /// Naive implementation of Enumerable.Range(int, int) for long.
            /// </summary>
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
