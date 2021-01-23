    var txtRange = "16,18,22-30";
    var tokens = txtRange.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
    .Select(t => new { 
        Token = t, 
        Range =  t.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
    })
    .Select(x => new{ x.Token, x.Range, 
        RangeStart = int.Parse(x.Range[0]),
        RangeEnd = x.Range.Length > 1 ? int.Parse(x.Range[1]) : int.Parse(x.Range[0])
    });
    int min = tokens.Min(x => x.RangeStart);
    int max = tokens.Max(x => x.RangeEnd);
    var list = new List<String>() { "11", "11A", "12", "12A", "13", "14", "15", "19" };
    var result = list.Select(s => new
    {
        Str = s,
        Num = int.Parse(new string(s.Where(Char.IsDigit).ToArray()))
    })
    .Where(x => x.Num >= min && x.Num <= max);
    foreach(var x in result)
        Console.WriteLine("String: {0} Numeric-Part: {1}", x.Str, x.Num);
