    private static int CountWords(string S)
    {
        if (S.Length == 0)
            return 0;
        S = S.Trim();
        while (S.Contains("  "))
            S = S.Replace("  "," ");
        return S.Split(' ').Length;
    }
