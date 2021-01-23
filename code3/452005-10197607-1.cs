    DateTime startingDate = DateTime.Parse("2012-04-13");
    foreach (var date in GetAlternatingWeekDay(startingDate).Take(10))
    {
        Console.WriteLine(date.ToString("R"));
    }
