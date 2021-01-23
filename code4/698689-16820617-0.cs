    var dates = new List<DateTime>
    {
        DateTime.Now.AddDays(-1),
        DateTime.Now.AddDays(-2),
        DateTime.Now.AddDays(-3),
        DateTime.Now.AddDays(-4),
        DateTime.Now.AddDays(-5),
        DateTime.Now.AddDays(-6),
        DateTime.Now.AddDays(-7),
        DateTime.Now.AddDays(-8)
    };
    var list = from date in dates
               where (DateTime.Now - date).Days < 7
               group date by date.Day;
    foreach (var dateGroup in list)
    {
        Console.WriteLine("Date group: " + dateGroup.Key);
        foreach (var date in dateGroup)
        {
            Console.WriteLine(date);
        }
    }
