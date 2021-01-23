    public IEnumerable<int> GetChildIds(IEnumerable<int> selectedParentIds)
    {
        using (var context = new MyContext())
        {
            var query = context.Children;
            foreach (var id in selectedParentIds)
            {
                query = query.Where(q => q.parentId == id);
            }
    
            return query.Select(q => q.Id)
                        .ToList();
        }
    }
