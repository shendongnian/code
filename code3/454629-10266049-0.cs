    class MeasuredOperation : IDisposable
    {
        Stopwatch stopwatch;
        string message;
        public MeasuredOperation(string message)
        {
            Console.WriteLine("Started {0}", message);
            stopwatch = Stopwatch.StartNew();
            this.message = message;
        }
        public void Dispose()
        {
            stopwatch.Stop();
            Console.WriteLine("Results of {0} Elapsed {1}", this.message, this.stopwatch.Elapsed);
        }
    }
        static void Main(string[] args)
        {
            using (new MeasuredOperation("foo action"))
            {
                // Do your action
            }
        }
