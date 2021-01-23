    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            var sw = new System.Diagnostics.Stopwatch();
            var loop = new List<long>();
            var recr = new List<long>();
            var std = new List<long>();
            var setSize = 100000;
            var runs = 50;
            Console.WriteLine("{0} runs of {1} items per set", runs, setSize);
            for (int j = 0; j < runs; j++)
            {
                // create number set
                var numbers = Enumerable.Range(1, setSize)
                                        .Select(s => r.Next(int.MinValue,
                                                            int.MaxValue))
                                        .ToArray();
                // loop
                sw.Start();
                for (int i = 0; i < setSize; i++)
                    IntegerToString.Iteration(numbers[i]);
                sw.Stop();
                loop.Add(sw.ElapsedTicks);
                // recursion
                sw.Reset();
                sw.Start();
                for (int i = 0; i < setSize; i++)
                    IntegerToString.Recursion(numbers[i]);
                sw.Stop();
                recr.Add(sw.ElapsedTicks);
                // standard
                sw.Reset();
                sw.Start();
                for (int i = 0; i < setSize; i++)
                    numbers[i].ToString();
                sw.Stop();
                std.Add(sw.ElapsedTicks);
            }
            Console.WriteLine();
            Console.WriteLine("Running Time:");
            Console.WriteLine("Iteration: {0} ({1} avg)", 
                              TimeSpan.FromTicks(loop.Sum()),
                              TimeSpan.FromTicks((int)loop.Average()));
            Console.WriteLine("Recursion: {0} ({1} avg)", 
                              TimeSpan.FromTicks(recr.Sum()),
                              TimeSpan.FromTicks((int)recr.Average()));
            Console.WriteLine("Standard : {0} ({1} avg)", 
                              TimeSpan.FromTicks(std.Sum()),
                              TimeSpan.FromTicks((int)std.Average()));
            double lSum = loop.Sum();
            double rSum = recr.Sum();
            double sSum = std.Sum();
            Console.WriteLine();
            Console.WriteLine("Ratios: \n" +
                              "     | Iter | Rec  | Std \n" +
                              "-----+------+------+-----");
            foreach (var div in new[] { new {n = "Iter", t = lSum}, 
                                        new {n = "Rec ", t = rSum},
                                        new {n = "Std ", t = sSum}})
                Console.WriteLine("{0} | {1:0.00} | {2:0.00} | {3:0.00}", 
                                  div.n, lSum / div.t, rSum / div.t, sSum / div.t);
            Console.ReadLine();
        }
