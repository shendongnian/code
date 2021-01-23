    public IEnumerable<int> GetChildIds(IEnumerable<int> selectedParentIds)
    {
    using (var context = new MyContext())
    {
        return context.Children
            .Where(c => selectedParentIds.Any( p => p == c.parentId ))
            .Select(c => c.Id)
            .ToList();
    }
    }
