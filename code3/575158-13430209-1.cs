    var pathParts = path.Split('/').ToList();
    
    var entities = 
        from entity in dataContext.Entities 
        select entity;
        
    pathParts.Reverse();
    
    for (int index = 0; index < pathParts.Count+ index++)
    {
        string pathPart = pathParts[index];
    
        switch (index)
        {
            case 0:
                entities = entities.Where(
                    entity.Code == pathPart);
                break;
            case 1:
                entities = entities.Where(
                    entity.Parent.Code == pathPart);
                break;
            case 2:
                entities = entities.Where(entity.Parent.Parent.Code == pathPart);
                break;
            case 3:
                entities = entities.Where(
                    entity.Parent.Parent.Parent.Code == pathPart);
                break;
            default:
                throw new NotSupportedException();
        }
    }
    
