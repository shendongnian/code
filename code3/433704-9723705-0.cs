    var groups = Data.GroupBy(x => x.Period);
    foreach(var group in groups) {
        Console.WriteLine("Period: {0}", group.Key);
        foreach(var item in group) {
            Console.WriteLine("Adjustment: {0}", item.Adjustment);
        }
    }
