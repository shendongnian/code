        class Program
        {
            static void Main(string[] args)
            {
                var A = new List<int>(Enumerable.Range(0, 10*1000*1000));
                var B = new List<int>(Enumerable.Range(0, 10*1000*1000));
        
                double[] Actual = UseLinq(A, B);
                double[] pActual = UseLinqParallel(A, B);
        
                var other = Optimized(A, B);
                var pother = OptimizedParallel(A, B);
            }
        
            private static double[] UseLinq(List<int> A, List<int> B)
            {
                var sw = Stopwatch.StartNew();
                var Merged = A.Zip(B, (a, b) => a + b);
                var Converted = A.Select(a => (float)a);
        
                var Result = Merged.Zip(Converted, (m, c) => Math.Cos((double)m / ((double)c + 1)));
        
                double[] Actual = Result.ToArray();
                sw.Stop();
        
                Console.WriteLine("Linq {0:F2}s", sw.Elapsed.TotalSeconds);
                return Actual;
            }
        
            private static double[] UseLinqParallel(List<int> A, List<int> B)
            {
                var sw = Stopwatch.StartNew();
                var Merged = A.Zip(B, (a, b) => a + b).ToArray();
                var Converted = A.Select(a => (float)a).ToArray();
        
                var Result = Merged.Zip(Converted, (m, c) => Math.Cos((double)m / ((double)c + 1))).AsParallel();
        
                double[] Actual = Result.ToArray();
                sw.Stop();
        
                Console.WriteLine("Linq Parallel {0:F2}s", sw.Elapsed.TotalSeconds);
                return Actual;
            }
        
            private static double[] OptimizedParallel(List<int> A, List<int> B)
            {
                double[] result = new double[A.Count];
                var sw = Stopwatch.StartNew();
                Parallel.For(0, A.Count, (i) =>
                {
                    var sum = A[i] + B[i];
                    result[i] = Math.Cos((double)sum / ((double)((float)A[i]) + 1));
                });
                sw.Stop();
        
                Console.WriteLine("Optimized Parallel {0:F2}s", sw.Elapsed.TotalSeconds);
                return result;
            }
        
            private static double[] Optimized(List<int> A, List<int> B)
            {
                double[] result = new double[A.Count];
                var sw = Stopwatch.StartNew();
                for(int i=0;i<A.Count;i++)
                {
                    var sum = A[i] + B[i];
                    result[i] = Math.Cos((double)sum / ((double)((float)A[i]) + 1));
                }
                sw.Stop();
        
                Console.WriteLine("Optimized {0:F2}s", sw.Elapsed.TotalSeconds);
                return result;
            }
        }
    }
