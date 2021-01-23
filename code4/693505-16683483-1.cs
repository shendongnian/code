    class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> dates = new List<DateTime>(){
            new DateTime(2003, 5, 21, 16, 0, 0), new DateTime(2003, 5, 21, 17, 0, 0),
            new DateTime(2003, 5, 21, 18, 0, 0), new DateTime(2003, 5, 21, 19, 0, 0),
            new DateTime(2003, 5, 21, 20, 0, 0), new DateTime(2003, 5, 21, 16, 0, 0),
            new DateTime(2003, 5, 21, 17, 0, 0), new DateTime(2003, 5, 21, 18, 0, 0),
            new DateTime(2003, 5, 21, 19, 0, 0), new DateTime(2003, 5, 21, 20, 0, 0),
            new DateTime(2003, 5, 21, 16, 0, 0), new DateTime(2003, 5, 21, 17, 0, 0),
            new DateTime(2003, 5, 21, 18, 0, 0), new DateTime(2003, 5, 21, 19, 0, 0),
            new DateTime(2003, 5, 21, 20, 0, 0), new DateTime(2003, 5, 21, 16, 0, 0),
            new DateTime(2003, 5, 21, 18, 0, 0), new DateTime(2003, 5, 21, 19, 0, 0),
            new DateTime(2003, 5, 21, 20, 0, 0), new DateTime(2003, 5, 21, 16, 0, 0),
            new DateTime(2003, 5, 21, 18, 0, 0), new DateTime(2003, 5, 21, 19, 0, 0),
            new DateTime(2003, 5, 21, 20, 0, 0), new DateTime(2003, 5, 21, 16, 0, 0),
            new DateTime(2003, 5, 21, 18, 0, 0), new DateTime(2003, 5, 21, 19, 0, 0),
            new DateTime(2003, 5, 21, 20, 0, 0), new DateTime(2003, 5, 21, 16, 0, 0),
            new DateTime(2003, 5, 21, 18, 0, 0), new DateTime(2003, 5, 21, 19, 0, 0),
            new DateTime(2003, 5, 21, 20, 0, 0), new DateTime(2003, 5, 21, 16, 0, 0),
            new DateTime(2003, 5, 21, 18, 0, 0), new DateTime(2003, 5, 21, 19, 0, 0),
            new DateTime(2003, 5, 21, 20, 0, 0), new DateTime(2003, 5, 21, 16, 0, 0),
            new DateTime(2003, 5, 21, 18, 0, 0), new DateTime(2003, 5, 21, 19, 0, 0),
            new DateTime(2003, 5, 21, 20, 0, 0), new DateTime(2003, 5, 21, 16, 0, 0),
        };
    
            var averageDate = dates.Average();
    
            Console.WriteLine(averageDate);
    
            Console.ReadKey();
        }
    
    }
    
    public static class Extensions
    {
        public static long Average(this IEnumerable<long> longs)
        {
            long count = longs.Count();
    
            long mean = 0;
    
            foreach (var val in longs)
            {
                mean += val / count;
            }
    
            return mean;
        }
    
        public static DateTime Average(this IEnumerable<DateTime> dates)
        {
            return new DateTime(dates.Select(x => x.Ticks).Average());
        }
    }
