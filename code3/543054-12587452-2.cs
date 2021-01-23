    var lst = new List<string[]>
    {
        { "ABC", "DEF", "GHI" },
        { "JKL", "MNO", "PQR" },
        ...
    }
    var blockEnd = new string[] { "EndOfBlock" };
    var newLst = lst.Select(a => 
        (a.Select(s => s).Concat(blockEnd))
        .ToArray()).ToList();
