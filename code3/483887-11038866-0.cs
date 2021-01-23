    string line = "LAST-MODIFIED:20120504T163940Z";
    var p = Regex.Match(line, "(.*)?(:|;)(.*)$", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline);
    Console.WriteLine(p.Groups[0].Value);
    Console.WriteLine(p.Groups[1].Value);
    Console.WriteLine(p.Groups[2].Value);
    Console.WriteLine(p.Groups[3].Value);
