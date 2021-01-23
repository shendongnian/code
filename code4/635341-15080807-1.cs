    public List<Model.ResourceCategory> GetResourcesWithDocuments()
    {
        using (var context = new SafetyInSightEntities())
        {
            return (from cat in context.ResourceCategory
                    orderby cat.Name
                    where cat.Resource.Any()
                    select new 
                    {
                        CategoryName = cat.Name,
                        Resources = cat.Resource.Where(r => r.IsProtected == false).ToList()
                    }).ToList();
        }
    }
