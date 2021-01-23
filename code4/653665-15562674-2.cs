    public static IEnumerable<T> Sort<T>(IList<T> lines, int columns)
    {
        var rows = lines.Count/columns;
        for (var i = 0; i < lines.Count; i++)
        {
            var index = rows > 0 && i < columns*rows
                ? (i%columns)*rows + i/columns
                : i;
            yield return lines[index];
        }
    }
