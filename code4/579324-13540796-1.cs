    public IQueryable<MenuItem> MakeQuery()
    {
    
        var parentsQuery =
            from parent in ctx.MenuItem
            where parent.ParentID == null
            orderby parent.ItemOrder
            select parent;
        
        var childrenQuery =
            from parent in parentsQuery
            join child in ctx.MenuItem
                on parent.ID equals child.ParentID
            where !ctx.MenuItem.Any(child2 => child2.ParentID == parent.ID
                && child2.ItemOrder < child.ItemOrder)
            orderby child.ItemOrder
            select child;
    
        return parentsQuery.Concat(childrenQuery);
    }
