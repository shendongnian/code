    public static IEnumerable<IEnumerable<Line>> GroupLines(IEnumerable<Line> lines)
    {
        var grouped = new Dictionary<Rectangle, IEnumerable<Line>>();
        foreach (var line in lines)
        {
            var boundedLines = new List<Line>(new[] { line });
            IEnumerable<Rectangle> crossedRectangles;
            var boundingRectangle = CalculateRectangle(boundedLines);
            while (
                (crossedRectangles = grouped.Keys
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
            grouped.Add(boundingRectangle, boundedLines);
        }
        return grouped.Values;
    }
    public static bool Crosses(Rectangle r1, Rectangle r2)
    {
        return !(r2.Left > r1.Right ||
            r2.Right < r1.Left ||
            r2.Top > r1.Bottom ||
            r2.Bottom < r1.Top);
    }
    public static Rectangle CalculateRectangle(IEnumerable<Line> lines)
    {
        Rectangle rtn = new Rectangle
        {
            Left = int.MaxValue,
            Right = int.MinValue,
            Top = int.MaxValue,
            Bottom = int.MinValue
        };
        foreach (var line in lines)
        {
            if (line.P1.X < rtn.Left) rtn.Left = line.P1.X;
            if (line.P2.X < rtn.Left) rtn.Left = line.P2.X;
            if (line.P1.X > rtn.Right) rtn.Right = line.P1.X;
            if (line.P2.X > rtn.Right) rtn.Right = line.P2.X;
            if (line.P1.Y < rtn.Top) rtn.Top = line.P1.Y;
            if (line.P2.Y < rtn.Top) rtn.Top = line.P2.Y;
            if (line.P1.Y > rtn.Bottom) rtn.Bottom = line.P1.Y;
            if (line.P2.Y > rtn.Bottom) rtn.Bottom = line.P2.Y;
        }
        return rtn;
    }
