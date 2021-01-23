    class Program {
        static void Main(string[] args) {
            List<double> testResults = new List<double>();
            Stopwatch sw = new Stopwatch();
            int lowerBound = int.Parse(args[0]);
            int upperBound = int.Parse(args[1]) + 1;
            int tests = int.Parse(args[2]);
            int sum = 0;
            for (int iTest = 0; iTest < tests; iTest++) {
                sum = 0;
                GC.Collect();
                sw.Reset();
                sw.Start();
                for (int lvl1 = lowerBound; lvl1 < upperBound; lvl1++)
                    for (int lvl2 = lowerBound; lvl2 < upperBound; lvl2++)
                        for (int lvl3 = lowerBound; lvl3 < upperBound; lvl3++)
                            for (int lvl4 = lowerBound; lvl4 < upperBound; lvl4++)
                                for (int lvl5 = lowerBound; lvl5 < upperBound; lvl5++)
                                    sum++;
                sw.Stop();
                testResults.Add(sw.Elapsed.TotalMilliseconds);
            }
            double avg = testResults.Average();
            double stdev = testResults.StdDev();
            string fmt = "{0,13} {1,13} {2,13} {3,13}"; string bar = new string('-', 13);
            Console.WriteLine();
            Console.WriteLine(fmt, "Iterations", "Average (ms)", "Std Dev (ms)", "Per It. (ns)");
            Console.WriteLine(fmt, bar, bar, bar, bar);
            Console.WriteLine(fmt, sum, avg.ToString("F3"), stdev.ToString("F3"),
                              ((avg * 1000000) / (double)sum).ToString("F3"));
        }
    }
    public static class Ext {
        public static double StdDev(this IEnumerable<double> vals) {
            double result = 0;
            int cnt = vals.Count();
            if (cnt > 1) {
                double avg = vals.Average();
                double sum = vals.Sum(d => Math.Pow(d - avg, 2));
                result = Math.Sqrt((sum) / (cnt - 1));
            }
            return result;
        }
    }
