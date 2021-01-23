    public static IEnumerable<T> UseTwoColumns<T>(List<T> list)
    {
        int halfway = list.Count / 2;
        for (int i = 0; i < halfway; i++)
        {
            yield return list[i];
            yield return list[halfway + i];
        }
        if (list.Count % 2 != 0)
            yield return list[list.Count - 1];
    }
