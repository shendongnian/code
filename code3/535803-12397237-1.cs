    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            Console.WriteLine("");
            Stopwatch watch1 = new Stopwatch();
            Stopwatch watch2 = new Stopwatch();
            List<double> list = getList();
            double prod = 1;
            double mean1 = -1;
            for (int c = 0; c < 2; c++)
            {
                watch1.Reset();
                watch1.Start();
                prod = 1;
                foreach (double d in list)
                {
                    prod *= d;
                }
                mean1 = Math.Pow(prod, 1.0 / (double)list.Count);
                watch1.Stop();
            }
            double mean2 = -1;
            for (int c = 0; c < 2; c++)
            {
                watch2.Reset();
                watch2.Start();
                double sum = 0;
                foreach (double d in list)
                {
                    double logged = Math.Log(d, 2);
                    sum += logged;
                }
                sum *= 1.0 / (double)list.Count;
                mean2 = Math.Pow(2.0, sum);
                watch2.Stop();
            }
            Console.WriteLine("First way gave: " + mean1);
            Console.WriteLine("Other way gave: " + mean2);
            Console.WriteLine("First way took: " + watch1.ElapsedMilliseconds + " milliseconds.");
            Console.WriteLine("Other way took: " + watch2.ElapsedMilliseconds + " milliseconds.");
            Console.WriteLine("");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
        private static List<double> getList()
        {
            List<double> result = new List<double>();
            Random rand = new Random();
            for (int i = 0; i < 50000000; i++)
            {
                result.Add( rand.NextDouble() / 100000.0 + 1);
            }
            return result;
        }
    }
