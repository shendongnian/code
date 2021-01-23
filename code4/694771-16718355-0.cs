    static IEnumerable<string> UnindentAsMuchAsPossible(IEnumerable<string> input)
    {
        int minDistance = input.Min(l => l.TakeWhile(Char.IsWhiteSpace).Count());
        return input.Select(l => l.Substring(minDistance));
    }
