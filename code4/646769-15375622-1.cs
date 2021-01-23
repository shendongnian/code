    var groups = PersistantDictionary.Instance.ToList()
            .GroupBy(x => searchTerm.Match(x.Value.Path).Value)
            .Where(g => g.Count() > 6500);
    foreach (var group in groups)
    {
        Console.WriteLine("{0} images for extension {1}", group.Count(), group.Key);
        foreach (KeyValuePair<string, CachedImage> pair in group)
        {
            //Do stuff with each CachedImage.
        }
    }
