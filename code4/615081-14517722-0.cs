     DateTime dt=DateTime.Parse(DateTime.Now.ToString("yyyy-01-01"));
       for (int i = 0; i < 365;i++ )
       {
           if (dt.AddDays(i).DayOfWeek==DayOfWeek.Friday)
           {
               Console.WriteLine(dt.AddDays(i).ToShortDateString());
           }
           
       }
