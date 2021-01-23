    const int Count = 10000000;
    const string testString = "<whatever>";
    // Solution No. 1: use Regex.Match()	
    Stopwatch sw = new Stopwatch();
    sw.Start();
    for (int i = 0; i < Count; i++)
    {
        var match = Regex.Match(@"\[\s*(\d+)\s*\]$", testString);
        if (!match.Success)
            continue;
        var number = int.Parse(match.Groups[1].Value);
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
    // Solution No. 2: use IndexOf() and Substring() shenanigans
    sw.Start();
    for (int i = 0; i < Count; i++)
    {
        var lb = testString.IndexOf('[');
        var rb = testString.LastIndexOf(']');
        if (lb < 0 || rb != testString.Length - 1)
            continue;
        var str = testString.Substring(lb + 1, rb - lb - 1);
        int number;
        if (!int.TryParse(str, out number))
            continue;
        // use the number
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
