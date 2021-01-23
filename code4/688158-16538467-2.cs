    string s = @"/s:http://asdasd.asd /e:device /f:create";
    string reg1 = @"(?=/s:)[^ ]+";
    string reg2 = "(?=/e:)[^ ]+";
    string reg3 = "(?=/f:)[^ ]+";
    Match match1 = Regex.Match(s, reg1, RegexOptions.IgnoreCase);
    if (match1.Success)
    {
       string key1 = match1.Groups[0].Value.Substring(3);
       Console.WriteLine(key1);
    }
    Match match2 = Regex.Match(s, reg2, RegexOptions.IgnoreCase);
    if (match2.Success)
    {
        string key2 = match2.Groups[0].Value.Substring(3);
        Console.WriteLine(key2);
    }
    Match match3 = Regex.Match(s, reg3, RegexOptions.IgnoreCase);
    if (match3.Success)
    {
        string key3 = match3.Groups[0].Value.Substring(3);
        Console.WriteLine(key3);
    }
