    class Program {
        static void Main(string[] args) {
            DateTime start = DateTime.Now.Subtract(TimeSpan.FromDays(170));
            DateTime stop = DateTime.Now;
            foreach (var interval in start.GetIntervals(stop))
                Console.WriteLine(interval);
            Console.ReadKey(intercept: true);
        }
    }
