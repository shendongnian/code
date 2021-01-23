    public ICollection<Model> ChildrenById
    {
        get
        {
            return Children == null 
                ? new List<Model>() 
                : Children
                   .OrderBy(c => c.Id)
                   .ToList();
        }
    }
