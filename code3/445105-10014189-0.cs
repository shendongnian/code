        static void Main(string[] args)
        {
            var dates = new List<DateTime> { new DateTime(2011, 5, 31), new DateTime(2012, 7, 31), new DateTime(2010, 1, 31) };
            dates.OrderBy(d => d.Ticks).ToList().ForEach(d => Console.WriteLine(d.ToString()));
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
