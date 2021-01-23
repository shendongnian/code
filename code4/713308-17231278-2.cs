    foreach (var byDate in result)
    {
        Console.WriteLine("Entries for date " + byDate.Date);
        foreach (var byTime in byDate.EntriesByTime)
        {
            Console.WriteLine("Total volume for time " + byTime.Time + ": " + byTime.TotalVolume);
        }
    }
