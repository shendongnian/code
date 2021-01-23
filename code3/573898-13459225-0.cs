    foreach (int id in primaryParentIds)
    {
        var parentResult = pList.Single(p => p.ParentId == id);
        parentResult.IsPrimary = true;
        pList.Entry(parentResult).EntityState = EntityState.Modified;
    }
    db.SaveChanges();
