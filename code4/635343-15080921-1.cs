    public IEnumerable<Model.ResourceCategory> GetResourcesWithDocuments() // return weaker interface
    {
        using (var context = new SafetyInSightEntities())
        {
            var q = from cat in context.ResourceCategory.Include(cat => cat.Resource)
                    orderby cat.Name
                    select new // anonymous, or compiler-time type
                    {
                        CategoryName = cat.Name,
                        Resources = cat.Resource.Where(r => !r.IsProtected).ToList(); // or ToArray()
                    };
            return q.ToList(); // or ToArray()
        }
    }
