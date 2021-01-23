    public static bool IsConsecutive(this IEnumerable<int> ints )
    {
        int start = ints.First();
        return !ints.Where((x, i) => x != i+start).Any();
    }
