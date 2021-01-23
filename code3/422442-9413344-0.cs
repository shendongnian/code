    class Program
    {
        static volatile int _outer = 0;
        static void Main(string[] args)
        {
            int inner = 0;
            Action act_outer1 = () => _outer++; // Interlocked.Increment(ref _outer);
            Action act_inner1 = () => inner++;  // Interlocked.Increment(ref inner);
            Action<int> combined = (i) => { act_outer1(); act_inner1(); };
            Console.WriteLine("None outer={0}, inner={1}", _outer, inner);
            Parallel.For(0, 20000000, combined);
            Console.WriteLine("Once outer={0}, inner={1}", _outer, inner);
            Console.ReadKey();
        }
    }
