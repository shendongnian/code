    class Program
    {
        static void Main()
        {
            const int SIZE = 1000000;
            const int K = 10;
            var random = new Random();
            var values = new int[SIZE];
            for (var i = 0; i < SIZE; i++)
                values[i] = random.Next(100);
            // Test values
            values[SIZE/2] = 200;
            values[SIZE/4] = 300;
            values[SIZE/8] = 400;
            IEnumerable<int> result;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            result = values.OrderByDescending(x => x).Take(K).ToArray();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            result = GetHighestValues(values, K).ToArray();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
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
