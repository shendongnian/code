    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Fibonacci().Take(10)));
            Console.WriteLine(string.Join(", ", Fibonacci().Skip(15).Take(1)));
            Console.WriteLine(string.Join(", ", Fibonacci().Skip(10).Take(5)));
            Console.WriteLine(string.Join(", ", Fibonacci().Skip(100).Take(1)));
            Console.ReadKey();
        }
        private static IEnumerable<long> Fibonacci()
        {
            long a = 0;
            long b = 1;
            while (true)
            {
                long temp = a;
                a = b;
                yield return a;
                b = temp + b;
            }
        }
    }
