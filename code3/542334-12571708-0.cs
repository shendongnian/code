    private static string SubstituteAmpersands(string url, string[] substitutes)
    {
        StringBuilder result = new StringBuilder();
        int substitutesIndex = 0;
        foreach (char c in url)
        {
            if (c == '&' && substitutesIndex < substitutes.Length)
                result.Append(substitutes[substitutesIndex++]);
            else
                result.Append(c);
        }
        return result.ToString();
    }
