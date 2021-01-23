    public static IEnumerable<List<T>> PowerSet<T>(List<T> startingSet, int minSubsetSize)
    {
        var startingSetIndexes = Enumerable.Range(0, startingSet.Count).ToList();
        var candidates = Enumerable.Range(0, 1 << startingSet.Count)
                                   .Where(p => NumberOfSetBits(p) >= minSubsetSize)
                                   .ToList();
        foreach (int p in candidates)
        {
            yield return startingSetIndexes.Where(setInd => (p & (1 << setInd)) != 0)
                                           .Select(setInd => startingSet[setInd])
                                           .ToList();
        }
    }
