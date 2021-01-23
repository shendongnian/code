    var strings = new[] { 
        "RS01","RS05A","RS10","RS102","RS105A","RS105B","RS32A","RS80"
    };
    strings = strings.Select(str => new
    {
        str,
        num = int.Parse(new string(str.Skip(2).TakeWhile(Char.IsDigit).ToArray())),
        version = new string(str.Skip(2).SkipWhile(Char.IsDigit).ToArray())
    })
    .OrderBy(x => x.num).ThenBy(x => x.version)
    .Select(x => x.str)
    .ToArray();
