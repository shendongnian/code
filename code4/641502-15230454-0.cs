    public IEnumerable<T> All()
    {
        // Ensure child collections are loaded
        return TypeOnes.Concat(TypeTwos).Concat(TypeThrees);
    }
