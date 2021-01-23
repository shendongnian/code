    public static void PermutateElements<T>(
        IEnumerable<T> elements,
        Predicate<IEnumerable<T>> filterGroup)
    {
        var chooseFrom = new LinkedList<T>(elements);
        var chosen = new List<T>(chooseFrom.Count);
        for (int chooseCount = 2; chooseCount < chooseFrom.Count - 1; chooseCount++)
        {
            Permutate(chooseFrom, chooseCount, filterGroup, chosen, 0);
        }
    }
    static bool Permutate<T>(LinkedList<T> chooseFrom, int chooseCount,
        Predicate<IEnumerable<T>> filterPermutation, IList<T> chosen, int skipLast)
    {
        int loopCount = chooseFrom.Count;
        for (int i = 0; i < loopCount; i++)
        {
            var choosingNode = chooseFrom.First;
            chooseFrom.RemoveFirst();
            bool removeChosen = false;
            if (i < loopCount - skipLast)
            {
                chosen.Add(choosingNode.Value);
                if (chooseCount == 1)
                    removeChosen = filterPermutation(chosen);
                else
                    removeChosen = Permutate(chooseFrom, chooseCount - 1, filterPermutation, chosen, skipLast + i);
                chosen.RemoveAt(chosen.Count - 1);
            }
            if (!removeChosen)
                chooseFrom.AddLast(choosingNode);
            else if (chosen.Count > 0)
                return true;
        }
        return false;
    }
