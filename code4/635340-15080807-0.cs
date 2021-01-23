    public List<Model.ResourceCategory> GetResourcesWithDocuments()
    {
        using (var context = new SafetyInSightEntities())
        {
            return (from cat in context.ResourceCategory.Include("Resource")
                    orderby cat.Name
                    where cat.Resource.Any(r => r.IsProtected == false)
                    select cat).ToList();
        }
    }
