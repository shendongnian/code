    using (var context = new YourContext()) {
        var val = 15;
        var query2 = context.Table
            .GroupBy(
                x => new {
                    IsGreaterThan = x.Column > val,
                    IsLessThan = x.Column < val
                },
                (key, data) => new { key = key, data = data.Select(x => x.Column) }
            )
            .Select(x => x.key.IsGreaterThan ? x.data.Min() : x.data.Max())
            .ToList();
        Console.WriteLine("First value larger than {0} = {1}", val, query2[0]);
        Console.WriteLine("First value smaller than {0} = {1}", val, query2[1]);
        Console.ReadLine();
        return;
    }
