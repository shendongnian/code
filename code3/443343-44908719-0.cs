    // Here are the results of selecting sum of 1 million ints on my machine:
    // Name    Iterations      Percent    
    // reiterate       294     53.3575317604356%      
    // constructor     551     100%
    public class A
    {
        public A()
        {            
        }
        public A(int b, int c)
        {
            Result = Sum(b, c);
        }
        public int Result { get; set; }
        public static int Sum(int source1, int source2)
        {
            return source1 + source2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var range = Enumerable.Range(1, 1000000).ToList();
            BenchmarkIt.Benchmark.This("reiterate", () =>
                {
                    var tst = range
                        .Select(x => new { b = x, c = x })
                        .AsEnumerable()
                        .Select(x => new A
                        {
                            Result = A.Sum(x.b, x.c)
                        })
                        .ToList();
                })
                .Against.This("constructor", () =>
                {
                    var tst = range
                        .Select(x => new A(x, x))
                        .ToList();
                })
                .For(60)
                .Seconds()
                .PrintComparison();
            Console.ReadKey();
        }
    }
