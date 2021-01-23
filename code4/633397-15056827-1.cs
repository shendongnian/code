    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                _rng = new Random(34324);
                int threadCount = 8;
                _maxBlocks = 200;
                ThreadPool.SetMinThreads(threadCount + 2, 4); // Kludge to prevent slow thread startup.
                var stopwatch = new Stopwatch();
                _numBlocks = _maxBlocks;
                stopwatch.Restart();
                var processor = new ParallelWorkProcessor<byte[]>(read, process, write, threadCount);
                processor.WaitForFinished(Timeout.Infinite);
                Console.WriteLine("\n\nFinished in " + stopwatch.Elapsed + "\n\n");
            }
            private static byte[] read()
            {
                if (_numBlocks-- == 0)
                {
                    return null;
                }
                var result = new byte[128];
                result[0] = (byte)(_maxBlocks-_numBlocks);
                Console.WriteLine("Supplied input: " + result[0]);
                return result;
            }
            private static byte[] process(byte[] data)
            {
                if (data[0] == 10) // Hack for test purposes. Make it REALLY slow for this item!
                {
                    Console.WriteLine("Delaying a call to process() for 5s for ID 10");
                    Thread.Sleep(5000);
                }
                Thread.Sleep(10 + _rng.Next(50));
                Console.WriteLine("Processed: " + data[0]);
                return data;
            }
            private static void write(byte[] data)
            {
                Console.WriteLine("Received output: " + data[0]);
            }
            private static Random _rng;
            private static int _numBlocks;
            private static int _maxBlocks;
        }
    }
