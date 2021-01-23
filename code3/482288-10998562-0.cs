    class Program
    {
        static void Main()
        {
            string s = "06/01/2012 8:00am";
            string format = "dd/MM/yyyy h:mmtt";
            DateTime date;
            if (DateTime.TryParseExact(s, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine(date);
            }
        }
    }
