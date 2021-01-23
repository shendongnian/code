       var days = new List<string> {"Tuesday", "Monday"};
       var startDate = new DateTime(2013, 7, 24).AddDays(1);
       while (!days.Contains(startDate.DayOfWeek.ToString("G")))
       {
            startDate = startDate.AddDays(1);
       }
       Console.WriteLine(startDate);
