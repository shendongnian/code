    static IEnumerable<string> UnindentAsMuchAsPossible(IEnumerable<string> input)
    {
        const int TabWidth = 4;
        if (!input.Any())
            return Enumerable.Empty<string>();
        int minDistance = input
            .Where(l => l.Length > 0)
            .Min(l => l
                .TakeWhile(Char.IsWhiteSpace)
                .Sum(c => c == '\t' ? TabWidth : 1));
        return input
            .Select(l => l
                .Substring(Math.Min(l.Length, minDistance)));
    }
