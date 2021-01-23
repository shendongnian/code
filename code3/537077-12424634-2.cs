    public static IEnumerable<IEnumerable<Line>> GroupLines(IEnumerable<Line> lines)
    {
        var grouped = new Dictionary<Rectangle, IEnumerable<Line>>();
        foreach (var line in lines)
        {
            IList<Line> boundedLines= new List<Line>();
            boundedLines.Add(line);
            IEnumerable<Rectangle> crossedRectangles;
            var boundingRectangle = CalculateRectangle(boundedLines);
            while (
                (crossedRectangles =
                    grouped.Keys
                        .Where(r => Crosses(boundingRectangle, r))
                        .ToList()
                ).Any())
            {
                foreach (var crossedRectangle in crossedRectangles)
                {
                    boundedLines.AddRange(grouped[crossedRectangle]);
                    grouped.Remove(crossedRectangle);
                }
               boundingRectangle = CalculateRectangle(boundedLines);
            }
            grouped.Add(newRectangle, newLines);
        }
        return grouped.Values;
    }
