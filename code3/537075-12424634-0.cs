    public static IEnumerable<IEnumerable<Line>> GroupLines(IEnumerable<Line> lines)
    {
        var grouped = new Dictionary<Rectangle, IEnumerable<Line>>();
        foreach (var line in lines)
        {
            var crossedRectangles =
                grouped.Keys.Where(r => Crosses(line, r)).ToList();
            var newLines = new[] { line }
                .Concat(crossedRectangles.SelectMany(r => grouped[r]));
            foreach (var crossedRectangle in crossedRectangles)
            {
                grouped.Remove(crossedRectangle);
            }
            var newRectangle = CalculateRectangle(newLines);
            grouped.Add(newRectangle, newLines);
        }
        return grouped.Values;
    }
