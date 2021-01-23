        public static Stopwatch stopWatch { get; } = new Stopwatch();
        static void Main(string[] args)
        {
            Console.WriteLine("DoAwaitTask: " + DoAwaitTask().Result + " ms");
            // 2050 (2000 more because of the await)
            Console.WriteLine("DoTask: " + DoTask() + " ms");
            // 50
            Console.ReadKey();
        }
       
