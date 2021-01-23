    public static List<SetDifference<T>> ComputeDifferences<T>(IList<List<T>> lists)
    {
        if (lists.Count == 0)
            return new List<SetDifference<T>>();
        var intersection = new HashSet<T>(lists.First());
        foreach (var list in lists.Skip(1))
        {
            intersection.IntersectWith(list);
        }
        var output = new List<SetDifference<T>>();
        foreach (var list in lists)
        {
            var difference = new SetDifference<T>(
                list: list,
                additionalObjects: list.Except(intersection),
                missingObjects: intersection.Except(list));
            output.Add(difference);
        }
        return output;
    }
