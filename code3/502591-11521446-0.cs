        static void Main(string[] args)
        {
            Console.WriteLine(ParseDate("19941201"));
            Console.ReadLine();
        }
        public static string ParseDate(string uglyDate)
        {
            return DateTime.ParseExact(uglyDate, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
        }
