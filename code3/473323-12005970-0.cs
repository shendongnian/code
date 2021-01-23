    class Program
    {
        static void Main(string[] args)
        {
            const int a = 10;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //for (long i = 0; i < a; i++)
            //{
            //    Thread.Sleep(1000);
            //}
            Parallel.For(0, a, i =>
            {
                Thread.Sleep(1000);
            });
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();
        }
    }
