    DateTime startDate = DateTime.Now;
    DateTime endDate = startDate.AddDays(35); //5 weeks
    var dates = GetOccurrences(startDate, startDate.AddDays(35), OccurrenceRate.Weekly);
    dates.ForEach(date =>
    {
        Console.WriteLine("{0:yyyy-MM-dd}", date);
    });
