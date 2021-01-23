    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(
        IEnumerable<T> elements,
        int chooseCount,
        Predicate<IEnumerable<T>> filterPermutation)
    {
        var chooseFrom = new LinkedList<T>(elements);
        if (chooseCount > chooseFrom.Count)
            throw new ArgumentException("chooseCount exceeds number of elements", "chooseCount");
        var chosen = new List<T>(chooseCount);
        var results = new List<IEnumerable<T>>();
        Permutate(chooseFrom, chooseCount, filterPermutation,
            chosen, 0, results);
        return results;
    }
    static void Permutate<T>(
        LinkedList<T> chooseFrom,
        int chooseCount,
        Predicate<IEnumerable<T>> filterPermutation,
        IList<T> chosen,
        int skipLast,
        IList<IEnumerable<T>> results)
    {
        int loopCount = chooseFrom.Count;
        for (int i = 0; i < loopCount; i++)
        {
            var choosingNode = chooseFrom.First;
            chooseFrom.RemoveFirst();
            if (i < loopCount - skipLast)
            {
                chosen.Add(choosingNode.Value);
                if (chooseCount == 1)
                {
                    if (filterPermutation(chosen))
                    {
                        var array = (T[])Array.CreateInstance(typeof(T), chosen.Count);
                        chosen.CopyTo(array, 0);
                        results.Add(array);
                    }
                }
                else
                    Permutate(chooseFrom, chooseCount - 1, filterPermutation, chosen, skipLast + i, results);
                chosen.RemoveAt(chosen.Count - 1);
            }
            chooseFrom.AddLast(choosingNode);
        }
    }
