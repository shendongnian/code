    public static decimal[] intRemover (string input)
    {
        return Regex.Matches(input,@"[+-]?\d+(\.\d+)?")
                    .Cast<Match>()
                    .Select(x=>decimal.Parse(x.Value))
                    .ToArray();
    }
