    class Program
    {
        static void Main(string[] args)
        {
            DateTime t = DateTime.Now; //Your selected date from Calendar
            t -= new TimeSpan((int)t.DayOfWeek, 0, 0, 0);
            Console.WriteLine("\tstart: " + t.Date.ToShortDateString());
            Console.WriteLine("\tend: " + t.Date.AddDays(7).ToShortDateString());
            Console.WriteLine("\t" + new string('-', 25));
            for (int i = 0; i < 7; i++)
            {
                var d = t.AddDays(i);
                if (d.DayOfWeek >= DayOfWeek.Monday && d.DayOfWeek <= DayOfWeek.Friday) //Range: Monday to Friday
                    Console.WriteLine(d.DayOfWeek + " : " + d);
            }
            Console.ReadLine();
        }
    }
   
