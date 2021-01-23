    public static IList<T> Sort<T>(IList<T> lines, int columns)
    {
        var rows = lines.Count/columns;
        if (rows == 0)
        {
            return lines;
        }
        return lines.Select((line, i) => new {line, i})
                    .OrderBy(item => item.i < columns*rows ? item.i%rows : rows)
                    .Select(item => item.line)
                    .ToList();
    }
