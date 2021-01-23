    public EntityTable Single(string path)
    {
        List<string> pathParts = path.Split('/').ToList();
        string code = pathParts.Last();
        var entities = dataContext.EntityTables.Where(e => e.Code == code);
        pathParts.RemoveAt(pathParts.Count - 1);
        return GetRecursively(entities, pathParts);
    }
    private EntityTable GetRecursively(IQueryable<EntityTable> entity, List<string> pathParts)
    {
        if (!(entity == null || pathParts.Count == 0))
        {
            string code = pathParts.Last();
            if (pathParts.Count == 1)
            {
                return entity.Where(x => x.EntityTable1.Code == code && x.ParentId == x.Id).FirstOrDefault();
            }
            else
            {                    
                pathParts.RemoveAt(pathParts.Count - 1);
                return this.GetRecursively(entity.Where(x => x.EntityTable1.Code == code), pathParts);
            }
        }
        else
        {
            return null;
        }
    }
