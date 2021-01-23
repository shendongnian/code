    public static IEnumerable<IList<T>> Combinations<T>(IEnumerable<IList<T>> collections)
    {
        if (collections.Count() == 1)
        {
            foreach (var item in collections.Single())
                yield return new List<T> { item };
        }
        else if (collections.Count() > 1)
        {
            foreach (var item in collections.First())
            foreach (var tail in Combinations(collections.Skip(1)))
                yield return new[] { item }.Concat(tail).ToList();
        }
    }
