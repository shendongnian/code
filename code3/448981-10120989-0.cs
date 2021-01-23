    using System;
    namespace DaySpan
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime startDate = DateTime.Parse("03.04.2012");
                DateTime endDate = DateTime.Parse("06.04.2012");
                Console.WriteLine(startDate.ToString());
                Console.WriteLine(endDate.ToString());
    
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Calculate dayspan:");
                TimeSpan span = endDate - startDate;
                Console.WriteLine("Span: " + span.TotalDays);
                Console.ReadLine();
            }
        } 
    }
