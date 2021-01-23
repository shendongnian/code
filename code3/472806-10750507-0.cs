    class Program
    {
        static void Main()
        {
            var startDate = new DateTime(2012, 5, 25);
            var endDate = new DateTime(2012, 5, 31);
            Console.WriteLine(IsValidDate(startDate, endDate));
        }
    
        public static bool IsValidDate(DateTime startDate, DateTime endDate)
        {
            return startDate < endDate && endDate > startDate;
        }
    }
