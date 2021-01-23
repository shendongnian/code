    public IEnumerable<IList<double>> GetCollectionOfCollections(IList<double> values, IList<double> boundries)
    {
        var ordered = values.OrderBy(x => x).ToList();
        for (int i = 0; i < boundries.Count; i++)
        {
            var collection = ordered.Where(x => x < boundries[i]).ToList();
            if (collection.Count > 0)
            {
                ordered = ordered.Except(collection).ToList();
                yield return collection.ToList();
            }
        }
        if (ordered.Count() > 0)
        {
            yield return ordered;
        }
    }
