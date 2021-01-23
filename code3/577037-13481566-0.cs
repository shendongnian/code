    public Entity Single(string path) {
        string[] pathParts = path.Split('/');
        string code = pathParts[pathParts.Length -1];
        if (pathParts.Length == 1)
                return dataContext.Entities.Single(e => e.Code == code && e.ParentID == 0);
        IQueryable<Entity> entities = dataContext.Entities.Where(e => e.Code == code);
        for (int i = pathParts.Length - 2; i >= 0; i--) {
            string parentCode = pathParts[i];
            entities = entities.Where(e => e.Entity1.Code == parentCode).Select(e => e.Entity1); //This now gets the parent entity
        }
        return entities.Single();
    }
