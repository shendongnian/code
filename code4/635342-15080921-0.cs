    public IEnumerable<Model.ResourceCategory> GetResourcesWithDocuments() // return weaker interface
    {
        using (var context = new SafetyInSightEntities())
        {
            var q = from cat in context.ResourceCategory.Include(cat => cat.Resource)
                    where cat.Resource.Any(r => !r.IsProtected)
                    orderby cat.Name
                    select cat;
            return q.ToList(); // or ToArray()
        }
    }
