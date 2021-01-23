    internal class Program
    {
        private static void Main(string[] args)
        {
            ListCreator.Register(SelfMadeList);
            var someIntegers = ListCreator.Create<int>();
            foreach (var item in someIntegers)
            {
                Console.WriteLine("Some integer: " + item);
            }
            var someDoubles = ListCreator.Create<double>();
            foreach (var item in someDoubles)
            {
                Console.WriteLine("Some doubles: " + item);
            }
            var someTimeSpans = ListCreator.Create<TimeSpan>();
            foreach (var item in someTimeSpans)
            {
                Console.WriteLine("Some timespans: " + item);
            }
            Console.ReadKey();
        }
        private static List<TimeSpan> SelfMadeList()
        {
            return Enumerable.Range(1, 20)
                             .Select(Convert.ToDouble)
                             .Select(val => val + 0.5)
                             .Select(TimeSpan.FromHours)
                             .ToList();
        }
    }
