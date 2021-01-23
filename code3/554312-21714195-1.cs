        static void Main(string[] args)
        {
            var st = Stopwatch.StartNew();
            Parallel.For(0, 100, _ =>
            {
                Counter.StartAsyncOperation();
                Thread.Sleep(100);
                Counter.EndAsyncOperation(1);
            });
            st.Stop();
            Console.WriteLine("Speed correct {0}", 100 / (double)st.ElapsedMilliseconds);
            Console.WriteLine("Speed to test {0}", Counter.GetAvgSpeed());
        }
