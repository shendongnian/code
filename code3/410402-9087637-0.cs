    public static IEnumerable<string> GetLinesBetween(
        string path,
        string fromInclusive,
        string toExclusive)
    {
        return File.ReadLines(path)
            .SkipWhile(line => line != fromInclusive)
            .TakeWhile(line => line != toExclusive);
    }
    var path = Path.Combine(sExecPath, sFileName); // don't combine paths like that
    var result = GetLinesBetween(path, "part1=001", "part2=002").ToList();
