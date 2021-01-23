    using System.Diagnostics;
    class Program
    {
        static void Main()
        {
            var stopwatch = new Stopwatch();
            var conditional = Conditional(10);
            var normal = Normal(10);
            var cached = Cached(10);
            if (new[] { conditional, normal }.Any(x => x != cached))
            {
                throw new Exception();
            }
            stopwatch.Start();
            conditional = Conditional(10000000);
            stopWatch.Stop();
            Console.WriteLine(
                "Conditional took {0}ms", 
                stopwatch.ElapsedMilliseconds);
            stopwatch.Start();
            normal = Normal(10000000);
            stopWatch.Stop();
            Console.WriteLine(
                "Normal took {0}ms", 
                stopwatch.ElapsedMilliseconds);
            stopwatch.Start();
            cached = Cached(10000000);
            stopWatch.Stop();
            Console.WriteLine(
                "Cached took {0}ms", 
                stopwatch.ElapsedMilliseconds);
            if (new[] { conditional, normal }.Any(x => x != cached))
            {
                throw new Exception();
            }
            Console.ReadKey();
        }
        static int Conditional(int iterations)
        {
            var ret = 0;
            for (int j = 0; j < iterations; j++)
            {
                ret = (j * 11 / 3 % 5) + (ret % 11 == 4 ? 2 : 1);
            }
            return ret;
        }
        static int Normal(int iterations)
        {
            var ret = 0;
            for (int j = 0; j < iterations; j++)
            {
                if (ret % 11 == 4)
                {
                    ret = 2 + (j * 11 / 3 % 5);
                }
                else
                {
                    ret = 1 + (j * 11 / 3 % 5);
                }
            }
            return ret;
        }
        static int Cached(int iterations)
        {
            var ret = 0;
            for (int j = 0; j < iterations; j++)
            {
                var tmp = j * 11 / 3 % 5;
                if (ret % 11 == 4)
                {
                    ret = 2 + tmp;
                }
                else
                {
                    ret = 1 + tmp;
                }
            }
            return ret;
        }
    }
