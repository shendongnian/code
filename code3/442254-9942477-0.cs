    try
    {
        c.SaveChanges();
    }
    catch (DbUpdateException ex)
    {                   
        IEnumerable<object> myBadEntities = 
            ex.Entries.Select(e => e.Entity);
    }
