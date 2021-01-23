    class Program
    {
        static void Main(string[] args)
        {
            var slots = new List<Tuple<DateTime, DateTime>>();
            DateTime start = FirstMonday(new DateTime(2012, 2, 28));
            DateTime end = FirstSunday(new DateTime(2012, 3, 6));
            for (DateTime i = start; i < end; i = i.AddDays(7))
            {
                slots.Add(new Tuple<DateTime, DateTime>(i, i.AddDays(6)));
            }
            foreach (var slot in slots)
            {
                Console.WriteLine("{0}\t{1}", slot.Item1.ToString("dd/MM/yyyy"), slot.Item2.ToString("dd/MM/yyyy"));
            }
            Console.ReadLine();
        }
        static DateTime FirstMonday(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Monday) date = date.AddDays(-1);
            return date;
        }
        static DateTime FirstSunday(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Sunday) date = date.AddDays(1);
            return date;
        }
    }
