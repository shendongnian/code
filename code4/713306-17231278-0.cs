    foreach (var byDate in result)
    {
        Console.WriteLine("Entries for date " + byDate.Date);
        foreach (var byTime in byDate.EntriesByTime)
        {
            Console.WriteLine("Entries for time " + byTime.Key);
            foreach (var entry in byTime)
            {
                Console.WriteLine(entry);
            }
        }
    }
