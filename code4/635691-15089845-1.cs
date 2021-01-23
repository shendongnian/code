    class Program
    {
        static void Main()
        {
            const int SIZE = 1000000;
            const int K = 10;
            var values = new int[SIZE];
            // Initialize values by random numbers
            var random = new Random();
            for (var i = 0; i < SIZE; i++)
                values[i] = random.Next(100);
            // Test values
            values[SIZE/2] = 200;
            values[SIZE/4] = 300;
            values[SIZE/8] = 400;
            IEnumerable<int> result;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            result = values.OrderByDescending(x => x).Take(K).ToArray(); // Original method
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds); // 738[ms]
            stopwatch.Restart();
            result = GetHighestValues(values, K).ToArray(); // Performance driven method
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds); // 14[ms]
        }
        static IEnumerable<int> GetHighestValues(IEnumerable<int> values, int count)
        {
            var maxSet = new List<int>(new int[count]);
            var currentMin = 0;
            foreach (var t in values)
            {
                if (t <= currentMin) continue;
                maxSet.Remove(currentMin);
                maxSet.Add(t);
                currentMin = maxSet.Min();
            }
            return maxSet.OrderByDescending(i => i);
        }
    }
