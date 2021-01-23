    public enum ChunkType
    {
        Weekly,
        Monthly,
        Yearly
    }
    
    public IEnumerable<IEnumerable<DateTime>> ChunkDates(IEnumerable<DateTime> collection, ChunkType chunkBy)
    {
        switch(chunkBy)
        {
            case ChunkType.Weekly:
                // roughly equals by day of week
                return collection.GroupBy(dt => dt.DayOfWeek).Select(grp => grp.ToList());
            case ChunkType.Monthly:
                // Trickier - assume by ordinal day of month?
                return collection.GroupBy(dt => dt.Day).Select(grp => grp.ToList());
            case ChunkType.Yearly:
                // Trickier - assume by ordinal day of year?
                return collection.GroupBy(dt => dt.DayOfYear).Select(grp => grp.ToList());        
        }
        return new[]{ collection };
    }
    var date1 = DateTime.Today;
    var date2 = DateTime.Today.AddDays(7);
    var date3 = DateTime.Today.AddDays(3);
    var date4 = DateTime.Today.AddDays(8*7);
    
    var collectionOfDateTime = new List<DateTime>() { date1, date2, date3, date4};
    
    foreach(var type in new [] { ChunkType.Weekly, ChunkType.Monthly, ChunkType.Yearly })
    {
        Console.WriteLine("Now grouping by:" + type);
        var grouped = ChunkDates(collectionOfDateTime, type);
        foreach(var groupOfDates in grouped)
        {
            Console.WriteLine("New group!");
            foreach (var value in groupOfDates)
            {
                Console.WriteLine(value);
            }
        }
    }
