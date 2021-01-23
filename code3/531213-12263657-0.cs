    var groups = list.Where(l => l.Contains('-'))
        .Select(l => new { l, tokens = l.Split('-') })
        .Where(x => x.tokens.Length > 1)
        .Select(x => new { Testcase = x.tokens[0], Result = x.tokens[1], Line = x.l })
        .GroupBy(x => x.Testcase)
        .OrderByDescending(g => g.Count());
    Console.WriteLine("Total:{0}", groups.Count());
    foreach(var g in groups)
        Console.WriteLine(String.Join(",", String.Format("{0}({1})", g.Key, g.Count())));
