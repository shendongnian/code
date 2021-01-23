    var m = regex.Match("Golden State 97 Indiana 108 (FINAL)");
    if (m.Success)
    {
        var string0 = m.Groups[1].Value; // Golden State
        var string1 = m.Groups[2].Value; // 97
        var string2 = m.Groups[3].Value; // Indiana
        var string3 = m.Groups[4].Value; // 108
        var string4 = m.Groups[5].Value; // FINAL
    }
