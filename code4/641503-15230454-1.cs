    // Option: Preserve duplicates between collections
    public IEnumerable<T> All()
    {
        // Ensure child collections are loaded
        return TypeOnes.Concat(TypeTwos).Concat(TypeThrees);
    }
    // Option remove duplicates between collections
    public IEnumerable<T> All()
    {
        // Ensure child collections are loaded
        return TypeOnes.Union(TypeTwos).Union(TypeThrees);
    }
