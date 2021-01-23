    public IEnumerable<BlogPost> GetAll(string[] tags,
        bool includeUnapprovedEntries = false) {
    
        return GetAll(includeUnapprovedEntries)
            .Where(x => x.Tags.Any(t => tags.Contains(t));
    }
