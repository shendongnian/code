    var sameNames = names
        .Where(n => n.Name.Length >= name.Length && n.Name.Substring(0,name.Length)==name);
    if (sameNames.Any())
    {
        var lastNameWithNumber = sameNames
            .Where(n => Char.IsDigit(n.Name.Last()))
            .Select(n => new { 
                n.Name, 
                Num = int.Parse(new string(n.Name.Reverse().TakeWhile(Char.IsDigit).Reverse().ToArray()))
            })
            .OrderByDescending(x => x.Num)
            .FirstOrDefault();
        if (lastNameWithNumber != null)
            name = name + (lastNameWithNumber.Num + 1);
        else
            name = name + "2";
    }
