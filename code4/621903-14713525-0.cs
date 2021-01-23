        static void Main(string[] args)
        {
            List<String> datestrings = new List<string>() {
                                "12/23/2012 09:51",
                                "9/27/2012 11:36",
                                "10/2/2012 12:28",
                                "10/3/2012 10:51" };
            List<DateTime> dates = datestrings.Select(a => DateTime.Parse(a)).OrderBy(a => a).ToList();
            foreach (var d in dates)
            {
                Console.WriteLine(d);
            }
            Console.ReadLine();
        }
