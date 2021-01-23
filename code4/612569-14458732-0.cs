    return File.ReadAllLines(inputFilePath).Select(l => l.Split('|')).Select(FindReplacePair.Create);
    public static FindReplacePair Create(string[] split)
    {
        return new FindReplacePair { Find = split.First(), Replace = split.Last() };
    }
