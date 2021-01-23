    class Program
    {
        static void Main(string[] args)
        {
            DateTime d1 = new DateTime(2001, 01, 01);
            DateTime d2 = new DateTime(2012, 12, 31);
            for (DateTime d11 = d1; d11 < d2; d11 = d11.AddDays(1))
            {
                if (d11.DayOfWeek == DayOfWeek.Friday && d11.Day == 13)
                {
                    Console.WriteLine(d11.ToString("MM/dd/yyyy"));
                }
            }
            Console.ReadKey();
        }
    }
