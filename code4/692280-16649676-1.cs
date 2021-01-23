    var MyCache = new Dictionary<string, Result>
    {
        {"My result 1", new Result("My result 1")},
        {"My result 2", new Result("My result 2")},
        {"My result 3", new Result("My result 3")},
        {"My result 4", new Result("My result 4")}
    };
    MyCache["My result 2"].IncreaseHits();
    MyCache["My result 2"].IncreaseHits();
    MyCache["My result 3"].IncreaseHits();
    foreach (var result in MyCache.OrderByDescending(x => x.Value.Hits))
    {
        Console.WriteLine(result.Value.Name + " - hits " + result.Value.Hits);
    }
