    public List<string[]> divStrings(int ExpectedStringsPerArray, string[] AllStrings)
    {
        return Enumerable.Range(0, (int)Math.Ceiling(AllStrings.Count() / (double)ExpectedStringsPerArray))
            .Select(g => AllStrings.Skip(g * ExpectedStringsPerArray).Take(ExpectedStringsPerArray).ToArray()).ToList();
    }
