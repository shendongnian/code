        private  static readonly Regex R1
            = new Regex(@"^\d+$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        private static readonly Regex R2
            = new Regex(@"M$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        private static readonly Regex R3
            = new Regex(@"^\d{4}-", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        private static void Main(string[] args)
        {
            string[] stringDates = new[]
                {
                    "1374755180",
                    "2013-07-25 14:26:00",
                    "7/25/2013 6:37:31 PM"
                };
            foreach (var s in stringDates)
            {
                DateTime date = default(DateTime);
                if (R1.IsMatch(s))
                    date = new DateTime(long.Parse(s));
                else if (R2.IsMatch(s))
                    date = DateTime.Parse(s);
                else if (R3.IsMatch(s))
                    date = DateTime.Parse(s);
                if (date != default(DateTime))
                    Console.WriteLine("{0}", date);
            }
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
