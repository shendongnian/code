    static void Main(string[] args)
    {  
        Random r = new Random();
    
        DateTime d1;
        DateTime d2;
        DateTime d3;
        DateTime d4;
    
        for (int i = 0; i < 100; i++)
        {
            d1 = new DateTime(2012,1, r.Next(1,31));
            d2 = new DateTime(2012,1, r.Next(1,31));
            d3 = new DateTime(2012,1, r.Next(1,31));
            d4 = new DateTime(2012,1, r.Next(1,31));
                    
            Console.WriteLine("span1 = " + d1.ToShortDateString() + " to " + d2.ToShortDateString());
            Console.WriteLine("span2 = " + d3.ToShortDateString() + " to " + d4.ToShortDateString());
            Console.Write("\t");
            Console.WriteLine(HelperFunctions.OverlappingDates(
                new Tuple<DateTime, DateTime>(d1, d2),
                new Tuple<DateTime, DateTime>(d3, d4)).ToString());
            Console.WriteLine();
        }
    
        Console.WriteLine("COMPLETE");
        System.Console.ReadKey();
    }
