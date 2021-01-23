    public static IEnumerable<Match> NestedMatches(this Regex regex, string input)
    {
        var potentialNested = new Queue<string>();
        foreach (Match m in regex.Matches(input))
        {
            yield return m;
            potentialNested.Enqueue(m.Groups["PotentialNested"].Value);
        }
        while (potentialNested.Count > 0)
        {
            foreach (Match m in regex.Matches(potentialNested.Dequeue()))
            {
                yield return m;
                potentialNested.Enqueue(m.Groups["PotentialNested"].Value);
            }
        }
    }
