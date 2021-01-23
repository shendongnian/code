    var objRegex = new System.Text.RegularExpressions.Regex(@"^(\d+)=\[([A-Z]+)\] ([A-Z]+) \{Q=(\d+) M=(\d+) B=(\d+) I=([a-z0-9\-]+)\}$");
    var objMatch = objRegex.Match("000=[GEN] OK {Q=1 M=1 B=002 I=3e5e65656-e5dd-45678-b785-a05656569e}");
    if (objMatch.Success)
    {
        Console.WriteLine(objMatch.Groups[1].ToString());
        Console.WriteLine(objMatch.Groups[2].ToString());
        Console.WriteLine(objMatch.Groups[3].ToString());
        Console.WriteLine(objMatch.Groups[4].ToString());
        Console.WriteLine(objMatch.Groups[5].ToString());
        Console.WriteLine(objMatch.Groups[6].ToString());
        Console.WriteLine(objMatch.Groups[7].ToString());
    }
