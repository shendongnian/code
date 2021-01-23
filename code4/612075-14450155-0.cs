     class Program
        {
           
            static void Main(string[] args)
            {
                DateTime dt = new DateTime(2013, 1, 22);
                DateTime t = DateTime.Now;
                t -= new TimeSpan((int)t.DayOfWeek, 0, 0, 0);
                Console.WriteLine("start:" + t.ToString());
                Console.WriteLine("end:" + t.AddDays(7));
                Console.WriteLine("-------List----");
    
                for (int i = 0; i < 7; i++)
                    Console.WriteLine("date: " + t.AddDays(i));
    
                Console.ReadLine();
            }
       }
