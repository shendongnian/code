    var counts = array1.Concat(array2)
                      .GroupBy(v => v)
                      .Select(g => new { Value=g.Key, Number=g.Count() });
    foreach(var item in counts.OrderBy(i => i.Value))
        Console.WriteLine("{0} = {1}", item.Value, item.Number);
