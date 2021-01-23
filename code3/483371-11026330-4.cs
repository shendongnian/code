    var regex = new Regex(@"^(?!\w*Debug\("")([^""]*""(?<Text>[^""]*)"")*.*$");
    var inputs = new[]
                     {
                         @"string a = ""something"";",
                         @"sring b = ""something else"" + "" more"";",
                         @"Print(""this should match"");",
                         @"Print(""So"" + ""should this"");",
                         @"Debug(""just some bebug text"");",
                         @"Debug(""more "" + ""debug text"");"
                     };
    foreach (var input in inputs)
    {
        Console.WriteLine(input);
        Console.WriteLine("=====");
        var match = regex.Match(input);
        var captures = match.Groups["Text"].Captures;
        for (var i = 0; i < captures.Count; i++)
        {
            Console.WriteLine(captures[i].Value);
        }
        Console.WriteLine("=====");
        Console.WriteLine();
    }
