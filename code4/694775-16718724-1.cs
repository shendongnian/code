    static IEnumerable<string> UnindentAsMuchAsPossible(IEnumerable<string> input)
    {
        const int TabWidth = 4;
        if (!input.Any())
        {
            return Enumerable.Empty<string>();
        }
        int minDistance = input
            .Where(line => line.Length > 0)
            .Min(line => line
                .TakeWhile(Char.IsWhiteSpace)
                .Sum(c => c == '\t' ? TabWidth : 1));
        return input
            .Select(line => line.Replace("\t", new string(' ', TabWidth)))
            .Select(line => line.Substring(Math.Min(l.Length, minDistance));
    }
