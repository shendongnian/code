    IEnumerable<string> lineGroups = File.ReadLines(path)
    .Select((l, i) => new { Line = l, Parts = l.Split() })
    .Select(x => new
    {
        Number = x.Parts.ElementAtOrDefault(2).TryGetInt() ?? 1,
        Col1 = x.Parts.ElementAtOrDefault(0),
        Col2 = x.Parts.ElementAtOrDefault(1),
        x.Line,
        x.Parts
    })
    .GroupBy(x =>new { x.Col1, x.Col2 })
    .Select((g, groupIndex) =>
        string.Format("{0}. {1} {2} {3}",
        groupIndex + 1, g.Key.Col1, g.Key.Col2, g.Sum(x => x.Number)));
