    var dates = new DateTime[] { new DateTime(2012, 9, 12), new DateTime(1904, 6, 4), new DateTime(2007, 5, 4) };
    foreach (var item in dates.OrderBy(d => d))
    {
        Console.WriteLine(item);
    }
    
    Console.WriteLine();
    var temp = dates.Select(d => d.ToString());
    foreach (var item in temp.OrderBy(d => d))
    {
        Console.WriteLine(item);
    }
