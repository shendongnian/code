    public static IEnumerable<SetDifference<T>> ComputeDifferences<T>(IList<List<T>> lists)
    {
        if (lists.Count == 0)
            yield break;
        var intersection = new HashSet<T>(lists.First());
        foreach (var list in lists.Skip(1))
        {
            intersection.IntersectWith(list);
        }
        var output = new List<SetDifference<T>>();
        foreach (var list in lists)
        {
            yield return new SetDifference<T>(
                list: list,
                additionalObjects: list.Except(intersection),
                missingObjects: intersection.Except(list));
        }
    }
