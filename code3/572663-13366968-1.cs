    static void Main(string[] args)
        {
            System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            DateTime dt = DateTime.Now; //Use current date as starting point
            for (int i = 0; i < 10; i++)
            {
               
                int weekNo = ci.Calendar.GetWeekOfYear(
                dt,
                ci.DateTimeFormat.CalendarWeekRule,
                ci.DateTimeFormat.FirstDayOfWeek
                 );
                int year = ci.Calendar.GetYear(dt);
                if (weekNo == 53) //if week number==53, then go to next week
                {
                    dt = dt.AddDays(7);
                    weekNo = ci.Calendar.GetWeekOfYear(
                    dt,
                    ci.DateTimeFormat.CalendarWeekRule,
                    ci.DateTimeFormat.FirstDayOfWeek
                     );
                    year = ci.Calendar.GetYear(dt);
                }
                dt = dt.AddDays(7);
                Console.WriteLine(weekNo + "-" + year);
            }
        }  
