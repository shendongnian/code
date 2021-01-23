    if (entity.Count() != 0)
    {
        foreach (var items in entity)
        {
            if (items.Status == 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    else
    {
        return false;
    }    
