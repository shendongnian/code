    class Program
    {
        static void Main(string[] args)
        {
            var maxParallelism = Environment.ProcessorCount;
            Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = maxParallelism }, ParseAndPersist);
        }
        public static void ParseAndPersist(FileInfo fileInfo)
        {
            //Load entire file
            //Parse file
            //Execute SQL asynchronously..the goal being to achieve maximum file throughput aside from any SQL execution latency
        }
    }
