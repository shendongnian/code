    public IQueryable<MenuItem> MakeQuery()
    {
    
        var query1 =
            from parent in ctx.MenuItem
            where parent.ParentID == null
            orderby parent.ItemOrder
            select parent;
        
        var query2 =
            from parent in query1
            join child in ctx.MenuItem
                on parent.ID equals child.ParentID
            where !ctx.MenuItem.Any(child2 => child2.ParentID == parent.ID
                && child2.ItemOrder < child.ItemOrder)
            orderby child.ItemOrder
            select child;
    
        return query1.Concat(query2);
    }
