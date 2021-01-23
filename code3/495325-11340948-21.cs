        private static void Main(string[] args)
        {
            var query1 = from r in RangeTable().AsQueryable() select r;
            query1.Dump("List of ranges:");
            Console.WriteLine();
            query1.CreateDates().Dump("Result list of dates:");
            Console.ReadLine();
        }
