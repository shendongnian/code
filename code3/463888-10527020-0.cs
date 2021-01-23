    private static bool ContainsAllCandidatesOnce(List<string> lotsOfCandidates)
    {
        foreach (string candidate in allCandidates)
        {
            if (lotsOfCandidates.Count(t => t.Equals(candidate)) != 1)
            {
                return false;
            }
        }
        return true;
    }
    private static IEnumerable<string> MissingCandidates(List<string> lotsOfCandidates)
    {
        List<string> missingCandidates = new List<string>();
        foreach (string candidate in allCandidates)
        {
            if (lotsOfCandidates.Count(t => t.Equals(candidate)) != 1)
            {
                missingCandidates.Add(candidate);
            }
        }
        return missingCandidates;
    }
