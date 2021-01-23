    class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> dates = new List<DateTime>(){
                new DateTime(2003, 5, 21, 15, 0, 0),
                new DateTime(2003, 5, 21, 19, 0, 0),
                new DateTime(2003, 5, 21, 20, 0, 0)
            };
    
            var averageTicks = (long) dates.Average(d => d.Ticks);
    
            // Prints 5/21/2003 6:00:00 PM
            Console.WriteLine(new DateTime(averageTicks));
    
            Console.ReadKey();
        }
    }
