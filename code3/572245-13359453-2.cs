    public static bool IsConsecutive(this IEnumerable<int> ints )
    {
        //if (!ints.Any())
        //    return true; //Is empty consecutive?
        // I think I prefer exception for empty list but I guess it depends
        int start = ints.First();
        return !ints.Where((x, i) => x != i+start).Any();
    }
