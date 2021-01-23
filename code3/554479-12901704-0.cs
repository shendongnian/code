        entities.Configuration.ProxyCreationEnabled = false;
        children = entities.Childs.AsNoTracking().ToList();
        parents = entities.Parents.AsNoTracking().ToList();
        parents[0].Childs = new List<Child>();
        foreach (var c in children)
        {
            if (c.ParentId == parents[0].ParentId)
            {
                c.Parent = parents[0];
                parents[0].Childs.Add(c);
            }
        }
