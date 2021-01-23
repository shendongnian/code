    using System.Diagnostics;
    namespace StackOverflow.Demos
    {
        class Program
        {
            public static void Main(string[] args) 
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                recur(10000, new object());
                timer.Stop();
                Console.WriteLine( timer.Elapsed.TotalMilliseconds.ToString());
                Console.ReadKey();
            }
            private static void recur(int a, object b)
            {
                if (a > 0)
                    recur(--a, b);
            }
        }
    }
