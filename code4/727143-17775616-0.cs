    // track exceptions that occurred in loops
    class ErrorInfo
    {
        public Exception Error { get; set; }
        public int Outer { get; set; }
        public int Inner { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // something to store execeptions from inner thread loop
            var errors = new ConcurrentBag<ErrorInfo>();
            // no need to wrap a try around this simple loop
            // unless you want an exception to stop the loop
            for (int outer = 0; outer < 10; outer++)
            {
                var tasks = new Task[50];
                for (int inner = 0; inner < 50; inner++)
                {
                    var outerLocal = outer;
                    var innerLocal = inner;
                    tasks[inner] = Task.Factory.StartNew(() =>
                        {
                            try
                            {
                                Thread.Sleep(innerLocal);
                                if (innerLocal % 5 == 0)
                                {
                                    throw new Exception("Test of " + innerLocal);
                                }
                            }
                            catch (Exception e)
                            {
                                errors.Add(new ErrorInfo
                                {
                                    Error = e,
                                    Inner = innerLocal,
                                    Outer = outerLocal
                                });
                            }
                        });
                }
                Task.WaitAll(tasks);
            }
            Console.WriteLine("Error bag contains {0} errors.", errors.Count);
            Console.ReadLine();
        }
    }
