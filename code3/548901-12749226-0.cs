    var data = new[]
        {
            new {GrpField = "RED", Qty = 1, Price = 10},
            new {GrpField = "RED", Qty = 2, Price = 10},
            new {GrpField = "RED", Qty = 1, Price = 50},
            new {GrpField = "BLUE", Qty = 2, Price = 30},
            new {GrpField = "BLUE", Qty = 2, Price = 50},
        };
    var grouped =
        from d in data
        group d by d.GrpField
        into g
        select new {Group = g.Key, Sum = g.Sum(x => x.Qty * x.Price)};
    foreach(var g in grouped)
        Console.WriteLine("{0} - {1}", g.Group, g.Sum);
