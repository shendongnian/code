    private static IEnumerable<int> GetWhiteSpacePos(string input)
    {
        int iPos = -1;
        while ((iPos = input.IndexOf(" ", iPos + 1, StringComparison.Ordinal)) > -1)
        {
            yield return iPos;
        }
    }
