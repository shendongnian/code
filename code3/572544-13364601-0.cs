    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            var path = @"E:\";
            Console.WriteLine("Finding all files inside {0} (recursive)", path);
            stopwatch.Restart();
            var allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            stopwatch.Stop();
            Output("Directory.GetFiles found", allFiles.Length, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            var filenames = allFiles.Select(Path.GetFileName).ToArray();
            stopwatch.Stop();
            Output("Path.GetFileName parsed", filenames.Length, stopwatch.ElapsedMilliseconds);
            
            Console.Read();
        }
        private static void Output(string action, int len, long timeMs)
        {
            Console.WriteLine("{0} {1} files in {2:#,##0} ms: {3:0.0} microseconds/file", action, len, timeMs, timeMs * 1000.0 / len);
        }
    }
