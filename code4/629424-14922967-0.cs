    var query =
        from z in db.Orders
        group z by z.OrderDate.Value.Hour into g
        select new Stime() { HourTime = g.Key, Count = g.Count() };
    foreach (var item in query)
    {
        Console.WriteLine("Hour : {0},Order(s) Number : {1}", item.HourTime, item.Count);
    }
