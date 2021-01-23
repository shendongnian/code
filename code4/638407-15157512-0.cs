    public static class DateTimeExtensions
    {
        public static DateTime MinValue(this DateTime sqlDateTime)
        {
            return new DateTime(1900, 01, 01, 00, 00, 00);
        }
    }
    
    
    DateTime date = DateTime.Now;
    Console.WriteLine("Minvalue is {0} ", date.MinValue().ToShortDateString());
