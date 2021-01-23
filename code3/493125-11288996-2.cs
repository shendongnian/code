    DateTime dt = new DateTime();
    dt = DateTime.Now.AddMonths(1);
    DateTime conditionDateTime = new DateTime(dt.Year, dt.Month,DateTime.DaysInMonth(dt.Year, dt.Month));
     for (DateTime dt1 = new DateTime(dt.Year, dt.Month, 1); dt1 <conditionDateTime; dt1 = dt1.AddDays(1))
         {
            Console.Write(dt1.ToShortDateString() + " : ");
            Console.WriteLine(dt1.DayOfWeek);
         }
